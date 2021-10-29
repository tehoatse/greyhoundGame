using System.Collections.Generic;
using System.IO;

namespace greyhoundGame
{
    class Results
    {
        public RaceGreyhound[] Form { get; set; } // not used?

        private List<Finisher> finishers = new List<Finisher>();

        public Results()
        {
            // it's empty!
        }

        public void AddFinisher(RaceGreyhound hound, int time)
        {
            finishers.Add(new Finisher(hound, time));
        }

        public void FinalPositions()
        {
            Finisher finalDog = finishers[finishers.Count -1];
            for (int dogCounter = 0;
                dogCounter <= finishers.Count;
                dogCounter++)
            {
                int finishingPosition = dogCounter + 1;
                
                Finisher currentHound = finishers[dogCounter];
                
                currentHound.Position = finishingPosition;

                if (currentHound == finalDog)
                    return;

                Finisher nextHound = finishers[currentHound.Position + 1];

                while(areDogsTied(currentHound, nextHound))
                {
                    nextHound.Position = finishingPosition;
                    dogCounter++;
                    if (nextHound == finalDog)
                        return;
                    nextHound = finishers[dogCounter + 1];
                }
            }
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

        private bool areDogsTied(Finisher currentHound, Finisher nextHound)
        {
            if (currentHound.Time == nextHound.Time &&
                currentHound.Hound.DistanceTravelled == nextHound.Hound.DistanceTravelled)
                return true;
            return false;

        }
    }
}
