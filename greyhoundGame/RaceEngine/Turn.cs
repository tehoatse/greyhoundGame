using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace greyhoundGame.RaceEngine
{
    internal class Turn
    {
        private Marshal _marshal;
        private int _timePassed;
        private PositionManager _positionManager;
        private MovementManager _movementManager; 

        public Turn(Marshal marshal)
        {
            _marshal = marshal;
            _timePassed = 0;
            _movementManager = new MovementManager(_marshal);
            _positionManager = new PositionManager(_marshal.Hounds.Length);
        }
        
        public bool RunTurn()
        {
            Pace pace = new Pace(_marshal);


            WobbleHoundStatistics();
            Console.WriteLine("\ntick");
            _timePassed++;
            bool raceGoing = true;

            AccelerateHounds();
            pace.RunPaces(_timePassed);
            TireHounds();

            _marshal.Hounds = _positionManager.GetPositions(_marshal.Hounds);
            raceGoing = !_marshal.Hounds.All(hound => hound.Finished);

            foreach (var hound in _marshal.Hounds)
            {
                string outString =
                $"{hound.CurrentPosition.Ordinal} " +
                $"{hound.Greyhound.Name} " +
                $"Speed: {hound.CurrentSpeed} " +
                $"Stam: {hound.CurrentStam} " +
                $"Distance to Finish: {hound.DistanceToFinish} " +
                $"Finished?: {hound.Finished}";
                if (hound.Finished)
                    outString += $" Finishing time: {hound.FinishedTime}";
                Console.WriteLine(outString);
            }
            return raceGoing;
        }

        private void AccelerateHounds()
        {
            foreach (var hound in _marshal.GetHounds())
            {
                if (!hound.Finished)
                    hound.Accelerate();
            }
        }

        private void TireHounds()
        {
            foreach (var hound in _marshal.GetHounds())
            {
                if (!hound.Finished)
                    hound.Tire();
            }
        }

        private void WobbleHoundStatistics()
        {
            foreach (var hound in _marshal.GetHounds())
                hound.WobbleStats();
        }
    }
}
