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

        public Race(Greyhound[] greyhounds)
        {
            Greyhounds = greyhounds;
            Distance = 500;
            raceHounds = new RaceGreyhound[greyhounds.Length];

            // so we're putting them all in the race, registering them basically and salting them at the same time
            for (int i = 0; i < Greyhounds.Length; i++)
            {
                raceHounds[i] = new RaceGreyhound(Greyhounds[i]);
            }
        }

        public Race(Greyhound[] greyhounds, int distance )
        {
            Greyhounds = greyhounds;
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

            while(raceGoing)
            {
                raceGoing = Tick();
            }
            
            var results = new Results();
            return results;
        }

        private bool Tick()
        {
            bool raceGoing = true;
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
                        hound.Finished = true;

                    if (hound.Finished)
                        finishedCounter++;

                    raceGoing = finishedCounter == raceHounds.Length;
                }
            }

            return raceGoing;
        }


    }

}
