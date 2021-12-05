using System;
using System.Collections.Generic;
using System.Text;

namespace greyhoundGame.RaceEngine
{
    internal class Marshal
    {
        private RaceTrack _track;
        private RaceGreyhound[] _hounds;

        public Marshal(RaceGreyhound[] hounds, RaceTrack track)
        {
            _hounds = hounds;
            _track = track;
        }

        public RaceTrack getTrack()
        {
            return _track;
        }

        public RaceGreyhound[] getHounds()
        {
            return _hounds;
        }

        public RaceGreyhound getHoundByLocation(int xCoord, int yCoord)
        {
            foreach (var hound in _hounds)
            {
                if(hound.Coordinates.XCoord == xCoord &&
                    hound.Coordinates.YCoord == yCoord)
                    return hound;
            }
            return null;
        }

        public RaceGreyhound getHoundByLocation(RaceSquare square)
        {
            foreach(var hound in _hounds)
            {
                if (square == hound.Coordinates)
                    return hound;
            }
            return null;
        }

    }
}
