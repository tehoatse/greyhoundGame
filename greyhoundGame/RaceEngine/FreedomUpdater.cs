using System;
using System.Collections.Generic;
using System.Text;

namespace greyhoundGame.RaceEngine
{
    public class FreedomUpdater : IQueueableCommand
    {
        private RaceGreyhound _hound;

        public void AddCommand(RaceGreyhound hound, int i)
        {
            _hound = hound;
        }

        public void UpdateHound()
        {
            _hound.NearbyHounds = false;
        }
    }
}
