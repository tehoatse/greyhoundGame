using System;

namespace greyhoundGame.RaceEngine
{
    class MovementManager
    {
        // a token is created for each hound every game 'turn'
        public RaceGreyhound[] Hounds { set; get; }
        public MovementToken[] Movements { get; set; }

        private int timePassedInRace;

        private const float FASTEST_POSSIBLE_HOUND = 70f;

        public MovementManager(RaceGreyhound[] hounds)
        {
            Hounds = hounds;
        }

        public void MovementGameTurn(int time)
        {
            timePassedInRace = time;
            CreateMovementTokens();
            for (int counter = 0; counter < FASTEST_POSSIBLE_HOUND; counter++)
                UpdateTokens();
        }

        private void CreateMovementTokens()
        {
            Movements = new MovementToken[Hounds.Length];
            foreach (RaceGreyhound hound in Hounds)
            {
                Movements[Array.IndexOf(Hounds, hound)] = new MovementToken(hound, FASTEST_POSSIBLE_HOUND);
            }
        }

        private void UpdateTokens()
        {
            foreach (var potentialPace in Movements)
            {
                potentialPace.UpdatePace(timePassedInRace);
            }
        }

    }
}
