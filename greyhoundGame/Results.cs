using System.Collections.Generic;
using System.IO;

namespace greyhoundGame
{
    class Results
    {
        // the greyhounds in the race
        // I'll need to put the finishers together and poll them
        // first across the line wins
        // if we have two cross the line at the same time then the closest to the line previous tick wins
        // if it's a draw they're both that position and the next position is discarded (1, 2, 2, 4, 5)
        // first I need that text file
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

        public void RaceDone()
        {
            // this is called after the race is done to figure out who finished where
            // probably don't need the 'finisher' class can probably just put that into RaceGreyHound

            for (int i = 0; i < finishers.Count; i++)
            {
                // going to use 'i' to allocate position
                
                // don't want to have the final doggie break things
                if(i < finishers.Count-1)
                {
                    // so if this doggie and the next doggie have the same time
                    if(finishers[i].Time == finishers[i + 1].Time)
                    {
                        // we have to check which doggie was closest to the finish last turn
                        // if both crossed at the same time: 
                        if (finishers[i].Hound.DistanceTravelled == finishers[i + 1].Hound.DistanceTravelled)
                        {
                            finishers[i].Position = i + 1;
                            finishers[i + 1].Position = i + 1;
                            i++; // incrementing i so the i+1 doggie is skipped, we already know where he landed
                        }
                        else if (finishers[i].Hound.DistanceTravelled > finishers[i + 1].Hound.DistanceTravelled)
                        {
                            finishers[i].Position = i + 1; // this doggie is further up
                            finishers[i + 1].Position= i + 2;
                            i++;
                        }
                        else
                        {
                            finishers[i].Position = i + 2;
                            finishers[i].Position = i + 1;
                            i++;
                        }

                    }
                    else
                    {
                        finishers[i].Position = i + 1;
                    }

                }

                else 
                {
                    finishers[i].Position = i + 1;
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
    }
}
