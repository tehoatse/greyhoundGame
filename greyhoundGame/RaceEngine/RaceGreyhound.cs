using System;

namespace greyhoundGame.RaceEngine
{
    public class RaceGreyhound
    {
        private const int PER_TURN_STAMINA_REDUCTION = 2;
        private const int STAT_DIVISOR = 3;
        private const int TENACITY_OFFSET = 125 / STAT_DIVISOR;
        private const int MINIMUM_SPEED = 5;

        private int _saltedAcceleration;
        private int _accelerationWobble;
        private int _currentSpeed;
        private int _speedWobble;
        private int _saltedTenacity;
        private int _tenacityWobble;

        private int SaltedTopSpeed { get; set; }

        public Greyhound Greyhound { get; private set; }

        public int CurrentSpeed
        {
            get
            {
                if (NearbyHounds)
                    return _currentSpeed + _speedWobble - 5;

                return _currentSpeed + _speedWobble;
            }
                
            set => _currentSpeed = value;
        }
        private int SaltedTenacity
        {
            get => _saltedTenacity + _tenacityWobble;
            set => _saltedTenacity = value;
        }
        private int SaltedAcceleration 
        {
            get => _saltedAcceleration + _accelerationWobble;
            set => _saltedAcceleration = value;
        }

        public bool NearbyHounds { get; set; }
        public int CurrentStam { get; set; }
        public int TimeLastTurn { get; private set; }
        public bool Finished { get; set; }
        public int FinishedTime { get; set; }
        public Position CurrentPosition { get; set; }
        public RaceSquare LocationLastTurn { get; private set; }
        public RaceSquare Coordinates { get; set; }
        public RaceTrack Track { get; set; }
        public int StartingBox { get; set; }
        public MovementDirection MoveDirection {get; set;}
        public int DistanceToFinish
        {
            get
            {
                if (Coordinates == Track.FinishLine)
                    return 0;
                return Track.Length - Coordinates.XCoord;
            }
        }

        public RaceGreyhound(Greyhound hound)
        {
            BuildHound(hound);
        }

        public RaceGreyhound(Greyhound hound, RaceTrack track)
        {
            BuildHound(hound);
            Track = track;
        }

        // generating a modifier to make thing random
        private int GetSalt()
        {
            Random dice = new Random();

            int result = dice.Next(1, 100);

            // so each statement has a return on it so I'm eliminating results
            // I'm not sure if the result periods are even and I don't care right now
            if (result <= 4)
                return -20; //nasty!
            if (result <= 20)
                return -10;
            if (result <= 40)
                return -5;
            if (result <= 60)
                return 0;
            if (result <= 80)
                return 5;
            if (result <= 97)
                return 10;
            return 20; // aaaaawesome!
        }
        private void BuildHound(Greyhound hound)
        {
            Greyhound = hound;
            _currentSpeed = 0;
            TimeLastTurn = 0;
            CurrentStam = Greyhound.Stats.Stamina.StatValue + GetSalt();
            SaltedTopSpeed = (Greyhound.Stats.TopSpeed.StatValue + GetSalt()) / STAT_DIVISOR;
            SaltedTenacity = (Greyhound.Stats.Tenacity.StatValue + GetSalt()) / STAT_DIVISOR;
            SaltedAcceleration = (Greyhound.Stats.Tenacity.StatValue + GetSalt()) /STAT_DIVISOR;
            Finished = false;                                                                          
            FinishedTime = -1;
            MoveDirection = MovementDirection.FORWARD;
        }

        public void Accelerate()
        {
            if (_currentSpeed < SaltedTopSpeed && CurrentStam != 0)
                _currentSpeed += SaltedAcceleration;
        }

        public void Tire()
        {
            if (!Finished && CurrentStam > 0)
                CurrentStam -= PER_TURN_STAMINA_REDUCTION;
            else 
            {
                CurrentStam = 0;
                CurrentSpeed -= (TENACITY_OFFSET - SaltedTenacity);
                
                if (CurrentSpeed < MINIMUM_SPEED)
                    CurrentSpeed = MINIMUM_SPEED;
            }
        }

        public void UpdatePosition(int time)
        {
            UpdateLocationLastTurn(time);

            if(!Finished)
                Coordinates = Track.GetSquare(MoveDirection, Coordinates);

            if (Coordinates == Track.FinishLine && !Finished)
            {
                Finished = true;
                FinishedTime = time;
            }
        }
        
        public float GetIncrement(float fastestHoundPace)
        {
            return fastestHoundPace / CurrentSpeed;
        }

        public override string ToString()
        {
            return $"{Greyhound.Name} {CurrentPosition.Ordinal} {_currentSpeed} {CurrentSpeed}";
        }

        private void UpdateLocationLastTurn(int timeNow)
        {
            if (timeNow > TimeLastTurn && !Finished)
            {
                LocationLastTurn = Coordinates;
                TimeLastTurn = timeNow;
            }
        }
        public void WobbleStats()
        {
            _accelerationWobble = StatWobble();
            _speedWobble = StatWobble();
            _tenacityWobble = StatWobble();
        }
        private int StatWobble()
        {
            Random dice = new Random();
            return dice.Next(-5, 6);
        }
    }

}
