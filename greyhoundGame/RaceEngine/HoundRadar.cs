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

        public RaceGreyhound Hound { get; private set; }
        public RaceSquare HoundLocation { get; private set; }

        private List<RaceSquare> nearbySquares;
        private Marshal _marshal;

        public List<RaceGreyhound> NearbyHounds { get; set; }

        public HoundRadar(RaceGreyhound hound, Marshal marshal)
        {
            Hound = hound;
            _marshal = marshal;
            HoundLocation = Hound.Coordinates;
        }
        
        private void refreshRadar()
        {
            NearbyHounds.Clear();
            HoundLocation = Hound.Coordinates;
            GetNearbySquares();
            foreach(var square in nearbySquares)
            {
                if (square.HasGreyhound)
                {
                    NearbyHounds.Add(_marshal.getHoundByLocation(square));
                }
            }
        }

        private void GetNearbySquares()
        {
            nearbySquares.Clear();
            foreach(var square in RelativeNearSquares)
            {
                nearbySquares.Add(Hound.Track.GetSquare(

                    HoundLocation.XCoord + square.Item1,
                    HoundLocation.YCoord + square.Item2));
            }
        }

    }
}
