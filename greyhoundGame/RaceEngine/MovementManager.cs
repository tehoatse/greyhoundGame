using System;

namespace greyhoundGame.RaceEngine
{
    class MovementManager
    {
        private Marshal _marshall;
        public RaceGreyhound[] Hounds { set; get; }
        public MovementToken[] Movements { get; set; }

        private int timePassedInRace;

        private const float FASTEST_POSSIBLE_HOUND = 70f;

        public MovementManager(Marshal marshal)
        {
            _marshall = marshal;
            Hounds = _marshall.GetHounds();
        }

        public void MovementGameTurn(int time)
        {
            timePassedInRace = time;
            CreateMovementTokens();
            for (int counter = 0; counter < FASTEST_POSSIBLE_HOUND; counter++)
                PerformRacePace();
        }

        private void CreateMovementTokens()
        {
            Movements = new MovementToken[Hounds.Length];
            foreach (RaceGreyhound hound in Hounds)
            {
                Movements[Array.IndexOf(Hounds, hound)] = new MovementToken(hound, FASTEST_POSSIBLE_HOUND);
            }
        }

        private void PerformRacePace()
        {
            _marshall.ActionCommandList();

            foreach (var potentialPace in Movements)
            {
                potentialPace.UpdatePace(timePassedInRace);
            }

            _marshall.RefreshEye();
            
            foreach (var radar in _marshall.Eye.Radar)
            {
                if(radar.NearbyHounds.Count > 0)
                {
                    SpeedIncrementer incrementer = new SpeedIncrementer();
                    incrementer.AddCommand(radar.Hound, -5);
                    _marshall.QueueCommand(incrementer);
                }
                else if(radar.NearbyHounds.Count == 0)
                {
                    FreedomUpdater updater = new FreedomUpdater();
                    updater.AddCommand(radar.Hound, 0);
                    _marshall.QueueCommand(updater);

                }
                else if(radar.HoundInFront != null)
                {
                    NewSpeedUpdater updater = new NewSpeedUpdater();
                    updater.AddCommand(radar.HoundInFront, radar.HoundInFront.CurrentSpeed);
                    _marshall.QueueCommand(updater);
                }
            }
        }
    }
}
