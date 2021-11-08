using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace greyhoundGame.RaceEngine
{
    class MovementManager
    {
        public RaceGreyhound[] Hounds { set; get; }
        public RaceTrack Track { get; set; }

        private int fastestHoundSpeed;
        private double increment;

        public MovementManager(RaceGreyhound[] hounds, RaceTrack track)
        {
            Hounds = hounds;
            Track = track;
        }

        public void MoveHounds()
        {
            fastestHoundSpeed = GetFastestHoundSpeed();
            increment = 1 / (double)fastestHoundSpeed;
            
            int counter = 0;
             
            foreach(var hound in hounds)
            {

            }

            // so for each count on the counter

            foreach(var hound in Hounds)
            {
                
            
            }

        }

        private int GetFastestHoundSpeed()
        {
            return Hounds.Max(hound => hound.CurrentSpeed);
        }
    }
}
