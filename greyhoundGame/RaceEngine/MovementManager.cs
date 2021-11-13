using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace greyhoundGame.RaceEngine
{
    class MovementManager
    {
        public RaceGreyhound[] Hounds { set; get; }
        public MovementToken[] Movements { get; set; }


        private int FASTEST_POSSIBLE_HOUND = 70;

        public MovementManager(RaceGreyhound[] hounds)
        {
            Hounds = hounds;
        }

        public void MovementGameTurn()
        {
            CreateMovementTokens();
            for (int counter = 0; counter < FASTEST_POSSIBLE_HOUND; counter++)
                AdvanceRace();
        }

        private void CreateMovementTokens()
        {
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
                    MovePace(potentialPace.Hound);
            }
        }

        private void MovePace(RaceGreyhound hound)
        {
            hound.Coordinates.HasGreyhound = false;
            hound.Coordinates.XCoord++;
            hound.Coordinates.HasGreyhound = true;
        }
    }
}
