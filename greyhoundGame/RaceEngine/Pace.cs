using System;
using System.Collections.Generic;
using System.Text;
using greyhoundGame.RaceEngine.RaceCommands;

namespace greyhoundGame.RaceEngine
{
    internal class Pace
    {
        public static float FASTEST_POSSIBLE_HOUND = 100f;
        private int _timePassedInRace;
        private Marshal _marshal;

        public Pace(Marshal marshal)
        {
            _timePassedInRace = 0;
            _marshal = marshal;
        }

        public void RunPaces(int timePassedInRace)
        {
            _timePassedInRace = timePassedInRace;
            _marshal.MovementManager.CreateMovementTokens();


            for(int paceCounter = 0; paceCounter < FASTEST_POSSIBLE_HOUND; paceCounter++)
            {
                _marshal.ActionCommandList();
                _marshal.MovementManager.PerformRacePace(timePassedInRace);
                _marshal.RefreshEye();
                _marshal.QueueEyeActions();
            }
        }

    }
}
