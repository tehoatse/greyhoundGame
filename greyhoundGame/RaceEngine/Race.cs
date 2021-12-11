using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace greyhoundGame.RaceEngine
{
    class Race
    {
        public Greyhound[] Greyhounds { get; private set; }
        private RaceTrack _track { get; set; }
        private RaceGreyhound[] _raceHounds;
        private Marshal _marshal;
        private Turn Turn;

        public Race(Greyhound[] greyhounds, GreyhoundTrack venue, int distance)
        {
            _track = new RaceTrack(venue, distance, greyhounds.Length);
            AddHounds(greyhounds, _track);
            _marshal = new Marshal(_raceHounds, _track);

        }

        public Results Start()
        {
            Turn = new Turn(_marshal);
            bool raceGoing = true;
            var results = new Results(_raceHounds);

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
            _raceHounds = new RaceGreyhound[hounds.Length];

            _raceHounds = Enumerable.Range(0, hounds.Length).Select(
                result => new RaceGreyhound(Greyhounds[result], track)).ToArray();
        }

        private bool Tick()
        {
            return Turn.RunTurn();
        }

        private void GetHoundsToStartingPositions()
        {
            foreach (var hound in _raceHounds)
            {
                hound.StartingBox = Array.IndexOf(_raceHounds, hound);
                hound.Coordinates = _track.GetSquare(0, Math.Abs((hound.StartingBox * RaceTrack.TrackSpacing) - _track.TrackWidth));
            }
        }           
    }


}
