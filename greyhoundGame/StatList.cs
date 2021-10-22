using System;

namespace greyhoundGame
{
    class StatList
    {
        // this is a list of statistics that all greyhounds have, valued from 1 to 120

        public Stat TopSpeed { get; set; }
        public Stat Stamina { get; set; }
        public Stat Acceleration { get; set; }
        public Stat Health { get; set; }
        public Stat Armor { get; set; }
        public Stat Confidence { get; set; }
        public Stat Tenacity { get; set; }
        public Stat Balance { get; set; }
        public Stat Agility { get; set; }
        public Stat Strength { get; set; }
        public Stat Aggression { get; set; }
        public Stat Fitness { get; set; }


        // creates a set of stats defaulting to 1
        public StatList()
        {
            CreateStats();
        }

        public StatList(int[] stats)
        {
            CreateStats(stats);
        }

        // returns a list of all the statistics on this list
        public Stat[] ListStats()
        {
            Stat[] returnList = {
                TopSpeed,
                Stamina,
                Acceleration,
                Health,
                Armor,
                Confidence,
                Tenacity,
                Balance,
                Agility,
                Strength,
                Aggression,
                Fitness
            };

            Console.WriteLine(returnList.Length);
            return returnList;
        }

        // the contructors use this to CreateStats()
        private void CreateStats()
        {
            TopSpeed = new Stat(GreyhoundStrings.TopSpeed, GreyhoundStrings.TopSpeedDesc);
            Stamina = new Stat(GreyhoundStrings.Stamina, GreyhoundStrings.StaminaDesc);
            Acceleration = new Stat(GreyhoundStrings.Accelertion, GreyhoundStrings.AccelerationDesc);
            Health = new Stat(GreyhoundStrings.Health, GreyhoundStrings.HealthDesc);
            Armor = new Stat(GreyhoundStrings.Armor, GreyhoundStrings.ArmorDesc);
            Confidence = new Stat(GreyhoundStrings.Confidence, GreyhoundStrings.ConfidenceDesc);
            Tenacity = new Stat(GreyhoundStrings.Tenacity, GreyhoundStrings.TenacityDesc);
            Balance = new Stat(GreyhoundStrings.Balance, GreyhoundStrings.BalanceDesc);
            Agility = new Stat(GreyhoundStrings.Agility, GreyhoundStrings.AgilityDesc);
            Strength = new Stat(GreyhoundStrings.Strength, GreyhoundStrings.StrengthDesc);
            Aggression = new Stat(GreyhoundStrings.Aggression, GreyhoundStrings.AggressionDesc);
            Fitness = new Stat(GreyhoundStrings.Fitness, GreyhoundStrings.FitnessDesc);

        }

        private void CreateStats(int[] stats)
        {
            CreateStats();
            var list = ListStats();

            // assigning stats
            for (int i = 0; i < list.Length; i++)
            {
                //Console.WriteLine(i);
                list[i].StatValue = stats[i];
            }
        }

        public override string ToString()
        {
            string outString = "";
            // get the ToStrings() from the stats
            Stat[] stats = ListStats();

            foreach (Stat stat in stats)
            {
                outString += stat.ToString();
            }
            return outString;
        }
    }
}
