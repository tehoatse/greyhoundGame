using System;
using System.Collections.Generic;
using System.Text;

namespace greyhoundGame.RaceEngine
{
    internal interface IQueueableCommand
    {
        void AddCommand(RaceGreyhound hound, int i);
        void UpdateHound();
    }
}
