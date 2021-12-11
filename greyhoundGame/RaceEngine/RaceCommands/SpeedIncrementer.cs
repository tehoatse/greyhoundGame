using System;
using System.Collections.Generic;
using System.Text;

namespace greyhoundGame.RaceEngine.RaceCommands
{
    public class SpeedIncrementer : IQueueableCommand
    {
        private RaceGreyhound _hound;
        
        public SpeedIncrementer(RaceGreyhound hound)
        {
            _hound = hound;
        }

        public void UpdateHound()
        {
            _hound.NearbyHounds = true;
        }
    }
}
