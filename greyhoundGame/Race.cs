using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

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
        private RaceTrack Track { get; set; }

        private RaceGreyhound[] raceHounds;


        // how many ticks have gone
        private int timePassed = 0;

        public Race(Greyhound[] greyhounds, GreyhoundTrack venue, int distance)
        {
            Positions = new PositionManager(greyhounds.Length);
            RaceLength = distance;
            Track = new RaceTrack(venue, distance, greyhounds.Length);
            AddHounds(greyhounds, Track);
  
        }

        public Results Start()
        {
            bool raceGoing = true;
            var results = new Results(raceHounds);

            
            foreach (var hound in raceHounds)
            {
                hound.StartingBox = Array.IndexOf(raceHounds, hound);
                hound.Coordinates = Track.getCoordinates(0, hound.StartingBox * RaceTrack.TrackSpacing);
            }
                        
            while(raceGoing)
            {
                raceGoing = Tick();
            }

            return results;
        }

        private void AddHounds(Greyhound[] hounds, RaceTrack track)
        {
            Greyhounds = hounds;
            raceHounds = new RaceGreyhound[hounds.Length];

            raceHounds = Enumerable.Range(0, hounds.Length).Select(
                result => new RaceGreyhound(Greyhounds[result], track)).ToArray();
        }

        private bool Tick()
        {
            Console.WriteLine("\ntick");
            timePassed++;
            bool raceGoing = true;
            
            foreach (var hound in raceHounds)
            {
                if (!hound.Finished)
                {
                    hound.Accelerate();
                    hound.Move(timePassed);
                    hound.Tire();
                }
            }
           
            raceHounds = Positions.GetPositions(raceHounds);
            raceGoing = !raceHounds.All(hound => hound.Finished);
         

            foreach (var hound in raceHounds)
            {
                string outString =
                $"{hound.CurrentPosition.Ordinal} " +
                $"{hound.Greyhound.Name} " +
                $"Speed: {hound.CurrentSpeed} " +
                $"Stam: {hound.CurrentStam} " +
                $"Distance to Finish: {hound.DistanceToFinish} " +
                $"Finished?: {hound.Finished}";
                if (hound.Finished)
                    outString += $" Finishing time: {hound.FinishedTime}";
                Console.WriteLine(outString);
            }

            return raceGoing;
        }

        private void ResultsDump(string dump)
        {
            File.AppendAllText("results.txt", dump);
        }
    }


}
