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

        public RaceGreyhound[] GetPositions(RaceGreyhound[] hounds)
        {

            var orderedHounds = GetFinishedHounds(hounds).Concat(GetRunningHounds(hounds)).ToArray();

            AllocatePositions(orderedHounds);
          
            return orderedHounds;
        }

#region private methods
        private void GeneratePositions()
        {
            Positions = new Position[StartingBoxes];
            foreach (int position in Enumerable.Range(1, StartingBoxes))
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
            if (!currentHound.Finished && 
                !nextHound.Finished &&
                currentHound.DistanceToFinish == nextHound.DistanceToFinish)
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

            if (houndIndex >= houndList.Length)
                return null;

            return houndList[houndIndex + 1];
        }

        private void AllocatePositions(RaceGreyhound[] racingHounds)
        {
            var currentHound = racingHounds[0];
            var finalHound = racingHounds[racingHounds.Length - 1];

            foreach (var position in Positions)
            {
                currentHound.CurrentPosition = position;
                
                if (currentHound == finalHound)
                    return;

                var nextHound = GetNextHound(racingHounds, currentHound);

                while(AreDogsTied(currentHound, nextHound))
                {
                    nextHound.CurrentPosition = position;
                    currentHound = nextHound;

                    if (currentHound == finalHound)
                        return;

                    nextHound = GetNextHound(racingHounds, currentHound);
                }
                currentHound = nextHound;
            }
        }

        private RaceGreyhound[] SortHoundsByPosition(RaceGreyhound[] hounds)
        {
            RaceGreyhound[] orderedHounds = hounds.OrderBy(hounds => hounds.CurrentPosition.Number).ToArray();
            return orderedHounds;
        }
    }
    #endregion
}
