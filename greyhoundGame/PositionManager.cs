using System;
using System.Linq;
using System.Collections;

namespace greyhoundGame
{
    class PositionManager
    {
        public Position[] Positions { get; private set; }

        public PositionManager(int startingBoxes)
        {
            Positions = Enumerable.Range(1, startingBoxes).Select(s => new Position(s)).ToArray();
        }

        public RaceGreyhound[] GetPositions(RaceGreyhound[] hounds)
        {
            return AllocatePositions(GetFinishedHounds(hounds).Concat(GetRunningHounds(hounds)).ToArray());
        }

#region private methods

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

        private RaceGreyhound[] AllocatePositions(RaceGreyhound[] racingHounds)
        {
            var currentHound = racingHounds.First();
            var finalHound = racingHounds.Last();
            int skipPositionsCounter = 0;

            foreach (var position in Positions)
            {
                if (skipPositionsCounter > 0)
                {
                    skipPositionsCounter--;
                    continue;
                }

                currentHound.CurrentPosition = position;

                if (currentHound == finalHound)
                    return racingHounds;

                var nextHound = GetNextHound(racingHounds, currentHound);

                while (AreDogsTied(currentHound, nextHound))
                {
                    skipPositionsCounter++;
                    nextHound.CurrentPosition = position;
                    currentHound = nextHound;

                    if (currentHound == finalHound)
                        return racingHounds;

                    nextHound = GetNextHound(racingHounds, currentHound);
                }
                currentHound = nextHound;
            }
            return racingHounds;
        }
    }
    #endregion
}
