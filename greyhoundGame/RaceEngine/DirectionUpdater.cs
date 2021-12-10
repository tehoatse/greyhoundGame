using System;
using System.Collections.Generic;
using System.Text;

namespace greyhoundGame.RaceEngine
{
    public class DirectionUpdater : IQueueableCommand
    {
        private RaceGreyhound _hound;
        private MovementDirection _direction;

        public void AddCommand(RaceGreyhound hound, int Direction)
        {
            _direction = (MovementDirection)Direction;
            _hound = hound;
        }

        public void UpdateHound()
        {
            _hound.MoveDirection = _direction;
        }
    }
}
