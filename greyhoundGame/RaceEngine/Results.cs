using System.Collections.Generic;
using System.IO;

namespace greyhoundGame.RaceEngine
{
    class Results
    {
        public RaceGreyhound[] Hounds { get; private set; }

        public Results(RaceGreyhound[] hounds)
        {
            Hounds = hounds;
        }

        public override string ToString()
        {
            string outString = "";
            
            foreach (var hound in Hounds)
            {
                outString += $"{hound.CurrentPosition.Ordinal} is {hound.Greyhound.Name}\n";
            }
            return outString;
        }

    }
}
