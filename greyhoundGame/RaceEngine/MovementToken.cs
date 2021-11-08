using System;
using System.Collections.Generic;
using System.Linq;

namespace greyhoundGame.RaceEngine
{
    public class MovementToken
    {
        public double Increment { get; set; }
        public RaceGreyhound Hounds {get; set;}
        public double DistanceMoved { get; set; }
    }
}
