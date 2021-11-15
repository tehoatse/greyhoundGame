using System;

namespace greyhoundGame.RaceEngine
{
    public class RaceGreyhound
    {

        public static int PER_TURN_STAMINA_REDUCTION = 2;
        public static int STAT_DIVISOR = 3;
        public static int TENACITY_OFFSET = 125;
        public static int MINIMUM_SPEED = 5;

        public Greyhound Greyhound { get; private set; }
        public int CurrentSpeed { get; set; }
        public int CurrentStam { get; private set; }
        public int SaltedTopSpeed { get; private set; }
        public int SaltedTenacity { get; private set; }
        public int SaltedAcceleration { get; private set; }
        public int DistanceTravelled { get; set; }
        public int TimeLastTurn { get; private set; }
        public bool Finished { get; set; }
        public int FinishedTime { get; set; }
        public Position CurrentPosition { get; set; }
        public RaceSquare LocationLastTurn { get; private set; }
        public RaceSquare Coordinates { get; set;}
        public RaceTrack Track { get; set; }
        public int StartingBox { get; set; }
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
            CurrentSpeed = 0;
            DistanceTravelled = 0;
            TimeLastTurn = 0;
            CurrentStam = (Greyhound.Stats.Stamina.StatValue + GetSalt());
            SaltedTopSpeed = Greyhound.Stats.TopSpeed.StatValue + GetSalt();
            SaltedTenacity = Greyhound.Stats.Tenacity.StatValue + GetSalt();
            SaltedAcceleration = Greyhound.Stats.Tenacity.StatValue + GetSalt();
            Finished = false;                                                                          
            FinishedTime = -1;
        }

        public void Accelerate()
        {
            if (CurrentSpeed < SaltedTopSpeed && CurrentStam != 0)
                CurrentSpeed += SaltedAcceleration / STAT_DIVISOR;
        }

        public void Tire()
        {
            if (!Finished && CurrentStam > 0)
                CurrentStam -= PER_TURN_STAMINA_REDUCTION;
            else 
            {
                CurrentStam = 0;
                CurrentSpeed -= (TENACITY_OFFSET - SaltedTenacity) / STAT_DIVISOR;
                
                if (CurrentSpeed < MINIMUM_SPEED)
                    CurrentSpeed = MINIMUM_SPEED;
            }
        }

        public void UpdatePosition(int time, MovementDirection movementDirection)
        {
            if(time > TimeLastTurn && !Finished)
            {
                LocationLastTurn = Coordinates;
                TimeLastTurn = time;
            }

            if(!Finished)
            {
                Coordinates = Track.GetSquare(movementDirection, Coordinates);
            }

            if (Coordinates == Track.FinishLine && !Finished)
            {
                
                Finished = true;
                FinishedTime = time;
            }

        }

        public override string ToString()
        {
            return $"{Greyhound.Name} {CurrentPosition.Ordinal}";
        }
    }

}
