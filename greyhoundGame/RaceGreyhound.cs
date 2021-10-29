using System;

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
        public Position CurrentPostion { get; set; } 

        public RaceGreyhound(Greyhound hound)
        {
            BuildHound(hound);
        }

        public RaceGreyhound(Greyhound hound, int raceLength)
        {
            BuildHound(hound);
            DistanceToFinish = raceLength;
        }

        // generating a modifier to make thing random
        private int GetSalt()
        {
            Random dice = new Random();

            int result = dice.Next(1, 100);

            // so each statment has a return on it so I'm eliminating results
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

        }
    }

}
