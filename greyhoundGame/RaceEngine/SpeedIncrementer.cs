using System;
using System.Collections.Generic;
using System.Text;

namespace greyhoundGame.RaceEngine
{
    public class SpeedIncrementer : IQueueableCommand
    {
        private RaceGreyhound _hound;
        private int _increment;

        public void AddCommand(RaceGreyhound hound, int increment)
        {
            _hound = hound;
            _increment = increment;
        }

        public void UpdateHound()
        {
            _hound.CurrentSpeed += _increment;
        }
    }
}
