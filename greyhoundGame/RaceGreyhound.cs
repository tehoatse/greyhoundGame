﻿using System;

namespace greyhoundGame
{
    class RaceGreyhound
    {
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
            CurrentStam = (Greyhound.Stats.Stamina.StatValue + GetSalt()) * 3;
            SaltedTopSpeed = Greyhound.Stats.TopSpeed.StatValue + GetSalt();
            SaltedTenacity = Greyhound.Stats.Tenacity.StatValue + GetSalt();
            SaltedAcceleration = Greyhound.Stats.Tenacity.StatValue + GetSalt();
            Finished = false;
            FinishedTime = -1;
        }

        public override string ToString()
        {
            return $"{Greyhound.Name} {CurrentPosition.Ordinal}";
        }
    }

}
