using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace greyhoundGame.RaceEngine
{
    class Race
    {
        public Greyhound[] Greyhounds { get; private set; }
        public int RaceLength { get; private set; }
        public PositionManager Positions { get; set; }
        private RaceTrack _track { get; set; }

        private RaceGreyhound[] raceHounds;
        private MovementManager raceMover;
        private Marshal _marshal;

        // how many ticks have gone
        private int timePassed = 0;

        public Race(Greyhound[] greyhounds, GreyhoundTrack venue, int distance)
        {
            Positions = new PositionManager(greyhounds.Length);
            RaceLength = distance;
            _track = new RaceTrack(venue, distance, greyhounds.Length);
            AddHounds(greyhounds, _track);
            _marshal = new Marshal(raceHounds, _track);
            raceMover = new MovementManager(_marshal);
        }

        public Results Start()
        {
            bool raceGoing = true;
            var results = new Results(raceHounds);

            GetHoundsToStartingPositions();

            while (raceGoing)
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
            WobbleHoundStatistics();
            Console.WriteLine("\ntick");
            timePassed++;
            bool raceGoing = true;

            AccelerateHounds();
            raceMover.MovementGameTurn(timePassed);
            TireHounds();
           
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
        private void AccelerateHounds()
        {
            foreach (var hound in raceHounds)
            {
                if (!hound.Finished)
                    hound.Accelerate();
            }
        }

        private void TireHounds()
        {
            foreach (var hound in raceHounds)
            {
                if (!hound.Finished)
                    hound.Tire();
            }
        }

        private void WobbleHoundStatistics()
        {
            foreach (var hound in raceHounds)
                hound.WobbleStats();
        }

        private void GetHoundsToStartingPositions()
        {
            foreach (var hound in raceHounds)
            {
                hound.StartingBox = Array.IndexOf(raceHounds, hound);
                hound.Coordinates = _track.GetSquare(0, Math.Abs((hound.StartingBox * RaceTrack.TrackSpacing) - _track.TrackWidth));
            }
        }           
    }


}
