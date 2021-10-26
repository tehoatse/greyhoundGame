using System;
using System.IO;

namespace greyhoundGame
{
    class Race
    {
        private const int defaultRace = 500;
        private const int tenacityOffset = 125;
        private const int statDivisor = 5; // some stats need to be divided by five to work with

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
            Distance = defaultRace;
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

            results.GiveHoundsPositions();
            return results;
        }

        private void AddHounds(Greyhound[] hounds)
        {
            Greyhounds = hounds;
            raceHounds = new RaceGreyhound[hounds.Length];

            // so we're putting them all in the race, registering them basically and salting them at the same time
            for (int adder = 0; adder < Greyhounds.Length; adder++)
            {
                raceHounds[adder] = new RaceGreyhound(Greyhounds[adder], Distance);
            }

        }

        private bool Tick(Results results)
        {
            timePassed++;
            bool going = true;
            int finishedCounter = 0;

            // looks like this is where the race logic will live
            // move each hound in the list

            foreach (var hound in raceHounds)
            {
                if (!hound.Finished)
                {
                    Accelerate(hound);
                    Tire(hound);
                    Move(hound);
                    CheckFinishLine(hound, results);

                    // we're gunna build the log string here
                    string outString = 
                        $"Name: {hound.Greyhound.Name} " +
                        $"Speed: {hound.CurrentSpeed} " +
                        $"Stam: {hound.CurrentStam} " +
                        $"Distance gone: {hound.DistanceTravelled} " +
                        $"Finished?: {hound.Finished}\n";

                    // text file is dumping just results here ! :DDD
                    LogText.Dump(outString);
                    ResultsDump(outString);
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

        private void Accelerate(RaceGreyhound hound)
        {
            if (hound.CurrentSpeed < hound.SaltedTopSpeed &&
                hound.CurrentStam != 0)
            {
                hound.CurrentSpeed += hound.SaltedAcceleration / statDivisor;
            }
        }

        private void Tire(RaceGreyhound hound)
        {
            if (!hound.Finished &&
                hound.CurrentStam != 0)
                hound.CurrentStam--;
            else // higher tenacity is good, we need to invert the result
            {
                hound.CurrentSpeed -= (tenacityOffset - hound.SaltedTenacity) / statDivisor;
                if (hound.CurrentSpeed < 5)
                    hound.CurrentSpeed = 5;
            }
        }

        private void CheckFinishLine(RaceGreyhound hound, Results results)
        {
            if (hound.DistanceTravelled >= Distance)
            {
                hound.Finished = true;
                results.AddFinisher(hound, timePassed);
                LogText.Dump("Finisher added!\n");
            }
        }

        private void Move(RaceGreyhound hound)
        {
            if (hound.DistanceTravelled <= Distance)
                hound.DistanceTravelled += hound.CurrentSpeed / statDivisor;
        }

        private void ResultsDump(string dump)
        {
            File.AppendAllText("results.txt", dump);
        }
    }


}
