using System;
using greyhoundGame.RaceEngine.RaceCommands;

namespace greyhoundGame.RaceEngine
{
    class MovementManager
    {
        private Marshal _marshal;
        public RaceGreyhound[] Hounds { set; get; }
        public MovementToken[] Movements { get; set; }

        public MovementManager(Marshal marshal)
        {
            _marshal = marshal;
            Hounds = _marshal.GetHounds();
        }

        public void CreateMovementTokens()
        {
            Movements = new MovementToken[Hounds.Length];
            foreach (RaceGreyhound hound in Hounds)
            {
                Movements[Array.IndexOf(Hounds, hound)] = new MovementToken(hound);
            }
        }

        public void PerformRacePace(int timePassedInRace)
        {
            foreach (var potentialPace in Movements)
            {
                potentialPace.UpdatePace(timePassedInRace);
            }
        }
    }
}
