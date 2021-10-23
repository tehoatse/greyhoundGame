using System.Collections.Generic;

namespace greyhoundGame
{
    class Results
    {
        // the greyhounds in the race
        public RaceGreyhound[] Form { get; set; } // not used?

        private List<Finisher> finishers = new List<Finisher>();

        public Results()
        {
            // it's empty!
        }

        public void AddFinisher(RaceGreyhound hound, int time)
        {
            finishers.Add(new Finisher(hound, time));
            finishers[finishers.Count-1].Position = finishers.Count; // this is stupid
        }

        public override string ToString()
        {
            string outString = "And the positions are decided!\n";

            foreach (var finisher in finishers)
            {
                outString += finisher.PositionName + "! ";
                outString += finisher.ToString() + "\n";
            }
            return outString;
        }
    }
}
