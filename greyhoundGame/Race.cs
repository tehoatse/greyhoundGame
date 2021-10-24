using System;
using System.IO;

namespace greyhoundGame
{
    class Race
    {
        // greyhounds run a race, lets see who's the fastest!
        // the greyhounds in the race
        public Greyhound[] Greyhounds { get; private set; }
        
        //the length of the race
        public int Distance { get; private set; }

        private RaceGreyhound[] raceHounds;

        // how many ticks have gone
        private int timePassed = 0;

        public Race(Greyhound[] greyhounds)
        {
            AddHounds(greyhounds);
            Distance = 500;

        }

        public Race(Greyhound[] greyhounds, int distance )
        {
            AddHounds(greyhounds);
            Distance = distance;
        }

        public Results Start()
        {
            /*
             * so the way this is to work when we his 'start' a race starts
             * it's made up of ticks
             * each tick checks - 
             * the speed of a hound + the stamina of a hound
             * if the speed is less than top speed increase speed by an increment based on acceleration
             * if decrease the current stamina
             * if stamina is used up, decrease speed by an increment based on tenacity
             * cool? cool.
             */

            bool raceGoing = true;
            var results = new Results();


            while(raceGoing)
            {
                raceGoing = Tick(results);
            }

            results.RaceDone();
            return results;
        }

        private void AddHounds(Greyhound[] hounds)
        {
            Greyhounds = hounds;
            raceHounds = new RaceGreyhound[hounds.Length];

            // so we're putting them all in the race, registering them basically and salting them at the same time
            for (int i = 0; i < Greyhounds.Length; i++)
            {
                raceHounds[i] = new RaceGreyhound(Greyhounds[i], Distance);
            }

        }

        private bool Tick(Results results)
        {
            timePassed++; // how long has the race been going?!
            bool going = true;
            int finishedCounter = 0;

            // looks like this is where the race logic will live
            // move each hound in the list

            foreach (var hound in raceHounds)
            {
                // if it's not finished then move it
                if (!hound.Finished)
                {
                    // hound not at top speed? increase top speed!
                    if (hound.CurrentSpeed < hound.SaltedTopSpeed && hound.CurrentStam != 0)
                        hound.CurrentSpeed += hound.SaltedAcceleration / 5;

                    // if it's not out of gas, use up a bit, if it is reduce its speed
                    if (hound.CurrentStam != 0)
                        hound.CurrentStam--;
                    else // higher tenacity is good, we need to invert the result
                        hound.CurrentSpeed -= (125 - hound.SaltedTenacity) / 5;

                    // can't have them stalling on the track
                    // this makes the hound minimum speed 5
                    if (hound.CurrentSpeed < 5)
                        hound.CurrentSpeed = 5;

                    // move a bit
                    if (hound.DistanceTravelled <= Distance)
                        hound.DistanceTravelled += hound.CurrentSpeed / 5;
                    else // you got there!!!!
                    {
                        // this isn't being reached, figure out why when I got brain!
                        hound.Finished = true;
                        
                    }

                    if (hound.DistanceTravelled >= Distance)
                    {
                        hound.Finished = true;
                        results.AddFinisher(hound, timePassed);
                        LogText.Dump("Finisher added!\n");
                    }

                    // we're gunna build the log string here
                    string outString = 
                        $"Name: {hound.Greyhound.Name} " +
                        $"Speed: {hound.CurrentSpeed} " +
                        $"Stam: {hound.CurrentStam} " +
                        $"Distance gone: {hound.DistanceTravelled} " +
                        $"Finished?: {hound.Finished}\n";

                    // text file is dumping just results here ! :DDD
                    LogText.Dump(outString);
                    resultsDump(outString);
                }
            }

            // is the race over?
            foreach (var hound in raceHounds)
            {
                if (hound.Finished)
                    finishedCounter++;

                if (finishedCounter >= raceHounds.Length)
                    going = false;

            }

            LogText.Dump("\n");
            Console.WriteLine("Tick!");
            return going;
        }

        private void resultsDump(string dump)
        {
            File.AppendAllText("results.txt", dump);
        }
    }


}
