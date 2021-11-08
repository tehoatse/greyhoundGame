using System;

namespace greyhoundGame
{
    class RaceGreyhound
    {
        public static int StatDivisor = 3;
        public static int TenacityOffset = 125;
        public static int MinimumSpeed = 5;

        public Greyhound Greyhound { get; private set; }
        public int CurrentSpeed { get; set; }
        public int CurrentStam { get; set; }
        public int SaltedTopSpeed { get; private set; }
        public int SaltedTenacity { get; private set; }
        public int SaltedAcceleration { get; private set; }
        public int DistanceTravelled { get; set; }
        public int DistanceToFinish { get; set; }
        public bool Finished { get; set; }
        public int FinishedTime { get; set; }
        public Position CurrentPosition { get; set; }
        public RaceSquare Coordinates { get; set;}
        public RaceTrack Track { get; set; }
        public int StartingBox { get; set; }

        public RaceGreyhound(Greyhound hound)
        {
            BuildHound(hound);
        }

        public RaceGreyhound(Greyhound hound, RaceTrack track)
        {
            BuildHound(hound);
            Track = track;
            DistanceToFinish = track.Length;
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
                CurrentSpeed += SaltedAcceleration / StatDivisor;
        }

        public void Tire()
        {
            if (!Finished && CurrentStam != 0)
                CurrentStam -= 3;
            else 
            {
                CurrentSpeed -= (TenacityOffset - SaltedTenacity) / StatDivisor;
                if (CurrentSpeed < MinimumSpeed)
                    CurrentSpeed = MinimumSpeed;
            }
        }

        public void Move(int time)
        {
            RaceSquare destination;

            if (!Finished)
            {
                DistanceTravelled += CurrentSpeed / StatDivisor;
                destination = Track.GetSquare(
                    Coordinates.XCoord + (CurrentSpeed / StatDivisor),
                    Coordinates.YCoord);

                MoveTo(destination);

                DistanceToFinish = (Coordinates == Track.FinishLine)
                    ? DistanceToFinish - CurrentSpeed / StatDivisor : 
                    Track.Length - Coordinates.XCoord;
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

        private void MoveTo(RaceSquare destination)
        {
            const int MOVE_UP = -1;
            const int MOVE_DOWN = 1;
            const int STRAIGHT = 0;
            
            int verticalMove = STRAIGHT;

            if (destination.YCoord > Coordinates.YCoord)
                verticalMove = MOVE_DOWN;
            if (destination.YCoord < Coordinates.YCoord)
                verticalMove = MOVE_UP;

            int verticalMoveTimer = (destination.XCoord - Coordinates.XCoord) / 2;
            int verticalMoveCounter = 0;

            while(Coordinates != destination)
            {
                verticalMoveCounter++;
                Coordinates.HasGreyhound = false;
                if (verticalMoveTimer == verticalMoveCounter)
                    Coordinates = Track.GetSquare(Coordinates.XCoord, Coordinates.YCoord + verticalMove);
                Coordinates = Track.GetSquare(Coordinates.XCoord + 1, Coordinates.YCoord);
                Coordinates.HasGreyhound = true;
            }
        }
    }

}
