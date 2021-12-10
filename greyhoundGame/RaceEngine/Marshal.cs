using System;
using System.Collections.Generic;
using System.Text;

namespace greyhoundGame.RaceEngine
{
    internal class Marshal
    {
        private RaceTrack _track;
        private RaceGreyhound[] _hounds;
        private List<IQueueableCommand> _commandList = new List<IQueueableCommand>();
        public AllSeeingEye Eye { get; }
        

        public Marshal(RaceGreyhound[] hounds, RaceTrack track)
        {
            _hounds = hounds;
            _track = track;
            Eye = new AllSeeingEye(this);
        }

        public RaceTrack GetTrack()
        {
            return _track;
        }

        public RaceGreyhound[] GetHounds()
        {
            return _hounds;
        }

        public RaceGreyhound GetHoundByLocation(int xCoord, int yCoord)
        {
            foreach (var hound in _hounds)
            {
                if(hound.Coordinates.XCoord == xCoord &&
                    hound.Coordinates.YCoord == yCoord)
                    return hound;
            }
            return null;
        }

        public RaceGreyhound GetHoundByLocation(RaceSquare square)
        {
            foreach(var hound in _hounds)
            {
                if (square == hound.Coordinates)
                    return hound;
            }
            return null;
        }

        public List<IQueueableCommand> GetCommandList()
        {
            return _commandList;
        }

        public void ActionCommandList()
        {
            foreach(var command in _commandList)
            {
                command.UpdateHound();
            }
        }

        public void QueueCommand(IQueueableCommand command)
        {
            _commandList.Add(command);
        }

        public void RefreshEye()
        {
            Eye.RefreshAllRadars();
        }

        public List<RaceSquare> GetSquaresWithHounds()
        {
            List<RaceSquare> SquaresWithHounds = new List<RaceSquare>();
            foreach (var hound in _hounds)
            {
                SquaresWithHounds.Add(hound.Coordinates);
            }
            return SquaresWithHounds;
        }

    }
}
