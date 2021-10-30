using System;
using System.Linq;
using System.Collections;

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
            int positionCounter = 0;
            var finishedHounds = GetFinishedHounds(hounds);
            var runningHounds = GetRunningHounds(hounds);
            positionCounter = AllocatePositions(finishedHounds, positionCounter);
            AllocatePositions(runningHounds, positionCounter);
         
            return SortHoundsByPosition(finishedHounds.Concat(runningHounds).ToArray());
        }

#region private methods
        private void GeneratePositions()
        {
            Positions = new Position[StartingBoxes];
            for (int position = 1; position <= StartingBoxes; position++)
            {
                Positions[position - 1] = new Position(position);
            }
        }

        private RaceGreyhound[] GetFinishedHounds(RaceGreyhound[] hounds)
        {
            var finishedHounds = from hound in hounds where (hound.Finished == true) select hound;
            var orderedFinishedHounds =
                (finishedHounds.OrderBy(
                    finishedHounds => finishedHounds.FinishedTime).ThenByDescending(
                    finishedHounds => finishedHounds.DistanceTravelled));
            return orderedFinishedHounds.ToArray();
        }

        private RaceGreyhound[] GetRunningHounds(RaceGreyhound[] hounds)
        {
            var runningHounds = from hound in hounds where (hound.Finished == false) select hound;
            var orderedRunningHounds =
                (runningHounds.OrderByDescending(
                    runningHounds => runningHounds.DistanceTravelled));

            return orderedRunningHounds.ToArray();
        }

        private bool AreDogsTied(RaceGreyhound currentHound, RaceGreyhound nextHound)
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

        private RaceGreyhound GetNextHound(RaceGreyhound[] houndList, RaceGreyhound hound)
        {
            int houndIndex = Array.IndexOf(houndList, hound);
            return houndList[houndIndex + 1];
        }

        private int AllocatePositions(RaceGreyhound[] hounds, int position)
        {
            if (hounds.Length == 0)
                return position;

            var lastHound = hounds[hounds.Length -1];

            for (int dogCounter = 0; dogCounter < hounds.Length; dogCounter++)
            {
                var hound = hounds[dogCounter];
                hound.CurrentPostion = Positions[position];
                if (hound != lastHound)
                {
                    var nextHound = GetNextHound(hounds, hound);
                    while (AreDogsTied(hound, nextHound))
                    {
                        nextHound.CurrentPostion = Positions[position];
                        if (nextHound == lastHound)
                            return position++;
                        nextHound = GetNextHound(hounds, nextHound);
                        dogCounter++;
                    }
                }
                position++;
            }

            return position;
        }

        private RaceGreyhound[] SortHoundsByPosition(RaceGreyhound[] hounds)
        {
            RaceGreyhound[] orderedHounds = hounds.OrderBy(hounds => hounds.CurrentPostion.Number).ToArray();
            return orderedHounds;
        }


    }
    #endregion
}
