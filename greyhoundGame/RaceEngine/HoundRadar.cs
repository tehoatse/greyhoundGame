using System;
using System.Collections.Generic;
using System.Text;

namespace greyhoundGame.RaceEngine
{
    internal class HoundRadar
    {
        // list of positions relative to hound
        static private List<Tuple<int, int>> RelativeNearSquares = new List<Tuple<int, int>>()
        {
            //list of coordinates x,y which are squares hounds are aware of
            Tuple.Create(0, 1), // for instance this is one ycoord higher than the hound
            Tuple.Create(0, 2),
            Tuple.Create(0, -1),
            Tuple.Create(0, -2),
            Tuple.Create(1, 1),
            Tuple.Create(1, 2),
            Tuple.Create(1, -1),
            Tuple.Create(1, -2),
            Tuple.Create(2, 0),
            Tuple.Create(2, 1),
            Tuple.Create(2, 2),
            Tuple.Create(2, -1),
            Tuple.Create(2, -2),
        };

        public RaceGreyhound NextHound { get; set; }

        public RaceGreyhound Hound { get; private set; }
        public RaceSquare HoundLocation { get; private set; }

        private List<RaceSquare> _nearbySquares;
        private Marshal _marshal;
        private List<RaceSquare> _squaresWithHounds;
        private RaceSquare _nextSquare;

        public List<RaceGreyhound> NearbyHounds { get; set; }

        public RaceGreyhound HoundInFront { get; private set; }

        public HoundRadar(RaceGreyhound hound, Marshal marshal)
        {
            Hound = hound;
            _marshal = marshal;
            HoundLocation = Hound.Coordinates;
            NearbyHounds = new List<RaceGreyhound>();
            _nearbySquares = new List<RaceSquare>();
        }
        
        public void RefreshRadar()
        {
            NearbyHounds.Clear();
            HoundLocation = Hound.Coordinates;
            FindNearbySquares();
            _squaresWithHounds = _marshal.GetSquaresWithHounds();


            foreach (var square in _nearbySquares)
            {
                foreach (var houndLocation in _squaresWithHounds)
                if (square == houndLocation )
                {
                    NearbyHounds.Add(_marshal.GetHoundByLocation(square));
                }
            }

            FindNextSquare();
            NextHound = null;

            foreach(var square in _squaresWithHounds)
            {
                if (square == _nextSquare)
                    NextHound = _marshal.GetHoundByLocation(_nextSquare);
            }
        }

        private void FindNearbySquares()
        {
            _nearbySquares.Clear();
            foreach(var square in RelativeNearSquares)
            {
                _nearbySquares.Add(Hound.Track.GetSquare(

                    HoundLocation.XCoord + square.Item1,
                    HoundLocation.YCoord + square.Item2));
            }
        }

        private void FindNextSquare()
        {
            _nextSquare = _marshal.GetTrack().GetSquare(Hound.Coordinates.XCoord +1, Hound.Coordinates.YCoord);
        }

    }
}
