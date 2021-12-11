using System;
using System.Collections.Generic;
using System.Text;

namespace greyhoundGame.RaceEngine.Utilities
{
    public static class Tools
    {
        public static int GetSalt()
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
    }
}
