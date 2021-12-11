using System;
using System.Collections.Generic;
using System.Text;

namespace greyhoundGame.RaceEngine.RaceCommands
{
    public class FreedomUpdater : IQueueableCommand
    {
        private RaceGreyhound _hound;

        public FreedomUpdater(RaceGreyhound hound)
        {
            _hound = hound;
        }

        public void UpdateHound()
        {
            _hound.NearbyHounds = false;
        }
    }
}
