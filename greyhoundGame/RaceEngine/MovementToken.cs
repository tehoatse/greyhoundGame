using System;
using System.Collections.Generic;
using System.Linq;

namespace greyhoundGame.RaceEngine
{
    public class MovementToken
    {
        
        public double HoundIncrement { get; set; }
        public RaceGreyhound Hound {get; set;}
        private double paceCount;

        public MovementToken(RaceGreyhound hound, double fastestHoundPace)
        {
            Hound = hound;
            HoundIncrement = 
                fastestHoundPace / ((double)Hound.CurrentSpeed/RaceGreyhound.STAT_DIVISOR);
            paceCount = 0;
        }

        public bool CountIncrement()
        {
            paceCount++;
            if (paceCount >= HoundIncrement)
            {
                paceCount = paceCount - HoundIncrement;
                return true;
            }
            return false;
        }
    }
}
