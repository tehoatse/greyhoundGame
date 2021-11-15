using System;

namespace greyhoundGame.RaceEngine
{
    class MovementManager
    {
        public RaceGreyhound[] Hounds { set; get; }
        public MovementToken[] Movements { get; set; }

        private int timePassedInRace;

        private const int FASTEST_POSSIBLE_HOUND = 70;

        public MovementManager(RaceGreyhound[] hounds)
        {
            Hounds = hounds;
        }

        public void MovementGameTurn(int time)
        {
            timePassedInRace = time;
            CreateMovementTokens();
            for (int counter = 0; counter < FASTEST_POSSIBLE_HOUND; counter++)
                AdvanceRace();
        }

        private void CreateMovementTokens()
        {
            Movements = new MovementToken[Hounds.Length];
            foreach (RaceGreyhound hound in Hounds)
            {
                Movements[Array.IndexOf(Hounds, hound)] = 
                    new MovementToken(hound, 
                    FASTEST_POSSIBLE_HOUND);
            }
        }

        private void AdvanceRace()
        {
            foreach (var potentialPace in Movements)
            {
                bool shouldHoundMove = potentialPace.CountIncrement();
                if (shouldHoundMove)
                    potentialPace.Hound.UpdatePosition(timePassedInRace, potentialPace.Direction);
            }
        }

    }
}
