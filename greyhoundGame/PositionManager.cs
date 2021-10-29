using System;
using System.Linq;

namespace greyhoundGame
{
    class PositionManager
    {
        public int StartingBoxes { get; private set; }
        public Position[] Positions { get; private set; }

        public PositionManager(int startingBoxes)
        {
            StartingBoxes = startingBoxes;
            GeneratePositions();
        }

        public RaceGreyhound[] SetPositions(RaceGreyhound[] hounds)
        {
            Console.WriteLine("setting positions");
            int positionCounter = 0;
            var finishedHounds = getFinishedHounds(hounds);
            var runningHounds = getRunningHounds(hounds);
            positionCounter = AllocatePositions(finishedHounds, positionCounter);
            AllocatePositions(runningHounds, positionCounter);
         
            return finishedHounds.Concat(runningHounds).ToArray();
        }

        private void GeneratePositions()
        {
            Positions = new Position[StartingBoxes];
            for (int position = 1; position <= StartingBoxes; position++)
            {
                Positions[position - 1] = new Position(position);
            }
        }

        private RaceGreyhound[] getFinishedHounds(RaceGreyhound[] hounds)
        {
            Console.WriteLine("checking finished hounds");
            var finishedHounds = from hound in hounds where (hound.Finished == true) select hound;
            var orderedFinishedHounds =
                (finishedHounds.OrderBy(
                    finishedHounds => finishedHounds.FinishedTime).ThenBy(
                    finishedHounds => finishedHounds.DistanceTravelled));
            return orderedFinishedHounds.ToArray();
        }

        private RaceGreyhound[] getRunningHounds(RaceGreyhound[] hounds)
        {
            Console.WriteLine("checking running hounds");
            var runningHounds = from hound in hounds where (hound.Finished == false) select hound;
            var orderedRunningHounds =
                (runningHounds.OrderBy(
                    runningHounds => runningHounds.DistanceTravelled));

            return orderedRunningHounds.ToArray();
        }

        private bool areDogsTied(RaceGreyhound currentHound, RaceGreyhound nextHound)
        {
            if (!currentHound.Finished && currentHound.DistanceToFinish == nextHound.DistanceToFinish)
                return true;
            if (!currentHound.Finished)
                return false;
            if (currentHound.FinishedTime == nextHound.FinishedTime &&
                currentHound.DistanceTravelled == nextHound.DistanceTravelled)
                return true;
            return false;
        }

        private RaceGreyhound getNextHound(RaceGreyhound[] houndList, RaceGreyhound hound)
        {
            int houndIndex = Array.IndexOf(houndList, hound);
            return houndList[houndIndex + 1];
        }

        private int AllocatePositions(RaceGreyhound[] hounds, int position)
        {
            if (hounds.Length == 0)
                return position;

            Console.WriteLine("allocating hounds");
            var lastHound = hounds[hounds.Length -1];

            for (int dogCounter = 0; dogCounter < hounds.Length; dogCounter++)
            {
                var hound = hounds[dogCounter];
                hound.CurrentPostion = Positions[position];
                Console.WriteLine("Position Allocated");

                if (hound != lastHound)
                {
                    var nextHound = getNextHound(hounds, hound);
                    while (areDogsTied(hound, nextHound))
                    {
                        nextHound.CurrentPostion = Positions[position];
                        if (nextHound == lastHound)
                            return position;
                        nextHound = getNextHound(hounds, nextHound);
                        dogCounter++;
                    }
                }
                position++;
            }

            return position;
        }


    }

}
