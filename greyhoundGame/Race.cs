﻿using System;
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
        
        
        public int RaceLength { get; private set; }

        public PositionManager Positions { get; set; }

        private RaceGreyhound[] raceHounds;

        // how many ticks have gone
        private int timePassed = 0;

        public Race(Greyhound[] greyhounds)
        {
            Positions = new PositionManager(greyhounds.Length);
            RaceLength = defaultRace;
            AddHounds(greyhounds, RaceLength);
            
        }

        public Race(Greyhound[] greyhounds, int distance)
        {
            Positions = new PositionManager(greyhounds.Length);
            RaceLength = distance;
            AddHounds(greyhounds, distance);
            
        }

        public Results Start()
        {
            bool raceGoing = true;
            var results = new Results(raceHounds);

            while(raceGoing)
            {
                raceGoing = Tick();
            }

            return results;
        }

        private void AddHounds(Greyhound[] hounds, int distance)
        {
            Greyhounds = hounds;
            raceHounds = new RaceGreyhound[hounds.Length];

            for (int adder = 0; adder < Greyhounds.Length; adder++)
            {
                raceHounds[adder] = new RaceGreyhound(Greyhounds[adder], distance);
            }

        }

        private bool Tick()
        {
            Console.WriteLine("\ntick");
            timePassed++;
            bool going = true;
            int finishedCounter = 0;

            foreach (var hound in raceHounds)
            {
                if (!hound.Finished)
                {
                    Accelerate(hound);
                    Tire(hound);
                    Move(hound);
                    CheckFinishLine(hound);
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

            raceHounds = Positions.GetPositions(raceHounds);

            foreach (var hound in raceHounds)
            {
                string outString =
                $"{hound.CurrentPosition.Ordinal} " +
                $"{hound.Greyhound.Name} " +
                $"Speed: {hound.CurrentSpeed} " +
                $"Stam: {hound.CurrentStam} " +
                $"Distance gone: {hound.DistanceTravelled} " +
                $"Finished?: {hound.Finished}";
                if (hound.Finished)
                    outString += $" Finishing time: {hound.FinishedTime}";
                Console.WriteLine(outString);
            }

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

        private void CheckFinishLine(RaceGreyhound hound)
        {
            if (hound.DistanceToFinish <= 0 && !hound.Finished)
            {
                hound.Finished = true;
                hound.FinishedTime = timePassed;
                Console.WriteLine("Finisher added!\n");
            }
        }

        private void Move(RaceGreyhound hound)
        {
            if (hound.DistanceToFinish <= RaceLength)
            {
                hound.DistanceTravelled += hound.CurrentSpeed / statDivisor;
                hound.DistanceToFinish -= hound.CurrentSpeed / statDivisor;
            }
        }

        private void ResultsDump(string dump)
        {
            File.AppendAllText("results.txt", dump);
        }
    }


}
