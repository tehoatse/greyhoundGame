using System;
using System.Collections.Generic;
using System.Text;

namespace greyhoundGame.RaceEngine.RaceCommands
{
    public class DirectionUpdater : IQueueableCommand
    {
        private RaceGreyhound _hound;
        private MovementDirection _direction;

        public DirectionUpdater(RaceGreyhound hound, MovementDirection direction)
        {
            _hound = hound;
            _direction = direction;
        }
        
        public void UpdateHound()
        {
            _hound.MoveDirection = _direction;
        }
    }
}
