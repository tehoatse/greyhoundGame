using System;

namespace greyhoundGame
{
    class RaceGreyhound
    {
        // we're using this class to describe a greyhound on raceday so we're not altering its stats on the day
        // I guess we're using this to add a bunch of data to greyhound
        public Greyhound Greyhound { get; }
        public int CurrentSpeed { get; set; }
        public int CurrentStam { get; set; }
        public int SaltedTopSpeed { get; private set; }
        public int SaltedTenacity { get; private set; }
        public int SaltedAcceleration { get; private set; }
        public int DistanceTravelled { get; set; }
        public bool Finished { get; set; }

        public RaceGreyhound(Greyhound hound)
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
    }

}
