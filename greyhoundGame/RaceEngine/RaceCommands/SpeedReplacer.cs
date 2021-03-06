using System;
using System.Collections.Generic;
using System.Text;

namespace greyhoundGame.RaceEngine.RaceCommands
{
    public class SpeedReplacer : IQueueableCommand
    {
        private RaceGreyhound _hound;
        private int _newSpeed;

        public SpeedReplacer(RaceGreyhound hound, int newSpeed)
        {
            _hound = hound;
            _newSpeed = newSpeed;
        }

        public void UpdateHound()
        {
            _hound.CurrentSpeed = _newSpeed;
        }
    }
}
