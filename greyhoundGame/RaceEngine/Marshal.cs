using System;
using System.Collections.Generic;
using System.Text;
using greyhoundGame.RaceEngine.RaceCommands;

namespace greyhoundGame.RaceEngine
{
    internal class Marshal
    {
        private RaceTrack _track;
        private RaceGreyhound[] _hounds;
        private List<IQueueableCommand> _commandList = new List<IQueueableCommand>();

        public RaceGreyhound[] Hounds 
        { 
            get => _hounds;
            set => _hounds = value;
        
        }
        public AllSeeingEye Eye { get; private set; }
        public MovementManager MovementManager { get; private set; }

        
        public Marshal(RaceGreyhound[] hounds, RaceTrack track)
        {
            _hounds = hounds;
            _track = track;
            Eye = new AllSeeingEye(this);
            MovementManager = new MovementManager(this);
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

        public void QueueEyeActions()
        {
            foreach (var radar in Eye.Radar)
            {
                if (radar.NearbyHounds.Count > 0)
                {
                    SpeedIncrementer incrementer = new SpeedIncrementer(radar.Hound);
                    QueueCommand(incrementer);
                }
                else if (radar.NearbyHounds.Count == 0)
                {
                    FreedomUpdater updater = new FreedomUpdater(radar.Hound);
                    QueueCommand(updater);

                }
                else if (radar.HoundInFront != null)
                {
                    SpeedReplacer updater = new SpeedReplacer(radar.Hound, radar.HoundInFront.CurrentSpeed);
                    QueueCommand(updater);
                }
            }
        }

    }
}
