using System;

namespace greyhoundGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's build us a baby greyhound!");
            Console.WriteLine("Building dat greyhound!");
            Greyhound baby = new Greyhound();
            Console.WriteLine(baby.ToString());   

        }
    }

    #region TODO
    public class Mutator
    {
        // everything that can affect a greyhound needs to be a mutator
    }

    public class Personality : Mutator
    {
        // a greyhound's personality is a mutator

    }

    public class Daughter : Mutator
    {
        // a daughter is a thing that a greyhound can be given to change it
    }

    public class Injury : Mutator
    {
        // a greyhound can be injured
    }

    public class Mood : Mutator
    {
        // a greyhound can have a mood
    }

    public class Weight : Mutator
    {
        // a greyhound has a weight
    }
    #endregion

    class Greyhound
    {
        // a greyhound has statistics
        public StatList Stats { get; set; }
        // a greyhound has a name
        public string Name { get; set; }
        public int Age { get; set; }
        
        public Greyhound()
        {
            // a baby greyhound
            Stats = new StatList();
            Name = "Baby Greyhound";
            Age = 0;
        }

        public override string ToString()
        {
            string outString = "";

            outString += $"Name: {Name}\n";
            outString += $"Age: {Age}\n";
            outString += Stats.ToString();

            return outString;
        }
    }

    class Stat
    {
        // the value of the statistic can't be less than 1, can't be more than 120, statistics over 80 are exceptional, over 100 unique
        private int _statistic;
        public int StatValue
        {
            get => _statistic;
            set
            {
                //can't be more than 120
                if (value > 120)
                    _statistic = 120;
                //can't be less than 1
                else if (value < 1)
                    _statistic = 1;
                else
                    _statistic = value;
            }
        }

        // extra stuff to add flavour
        public string Name { get; set; }
        public string Description { get; set; }

        // constructors. there's no point of having a greyhound without a stat, also gamefalldown so have a stat please!
        public Stat()
        {
            StatValue = 1;
        }

        public Stat(int stat)
        {
            StatValue = stat;
        }

        // we want to give a greyhound basic stats starting with 1 
        public Stat(string name, string desc)
        {
            Name = name;
            Description = desc;
            StatValue = 1;
        }

        // giving a statistic a name, a description and a number
        public Stat(string name, string desc, int newStat)
        {
            StatValue = newStat;
            Name = name;
            Description = desc;
        }

        public override string ToString()
        {
            return $"{Name}: {StatValue} - {Description}\n";
        }
    }

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
            TopSpeed = new Stat(GreyHoundStrings.TopSpeed, GreyHoundStrings.TopSpeedDesc);
            Stamina = new Stat(GreyHoundStrings.Stamina, GreyHoundStrings.StaminaDesc);
            Acceleration = new Stat(GreyHoundStrings.Accelertion, GreyHoundStrings.AccelerationDesc);
            Health = new Stat(GreyHoundStrings.Health, GreyHoundStrings.HealthDesc);
            Armor = new Stat(GreyHoundStrings.Armor, GreyHoundStrings.ArmorDesc);
            Confidence = new Stat(GreyHoundStrings.Confidence, GreyHoundStrings.ConfidenceDesc);
            Tenacity = new Stat(GreyHoundStrings.Tenacity, GreyHoundStrings.TenacityDesc);
            Balance = new Stat(GreyHoundStrings.Balance, GreyHoundStrings.BalanceDesc);
            Agility = new Stat(GreyHoundStrings.Agility, GreyHoundStrings.AgilityDesc);
            Strength = new Stat(GreyHoundStrings.Strength, GreyHoundStrings.StrengthDesc);
            Aggression = new Stat(GreyHoundStrings.Aggression, GreyHoundStrings.AggressionDesc);
            Fitness = new Stat(GreyHoundStrings.Fitness, GreyHoundStrings.FitnessDesc);

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

    class Race
    {
        // greyhounds run a race, lets see who's the fastest!
        // the greyhounds in the race
        public Greyhound[] Greyhounds { get; private set; }
        
        //the length of the race
        public int Length { get; private set; }

        private RaceGreyhound[] raceHounds;

        public Race(Greyhound[] greyhounds)
        {
            Greyhounds = greyhounds;
            Length = 500;
            raceHounds = new RaceGreyhound[greyhounds.Length];

            // so we're putting them all in the race, registering them basically and salting them at the same time
            for (int i = 0; i < Greyhounds.Length; i++)
            {
                raceHounds[i] = new RaceGreyhound(Greyhounds[i]);
            }
        }

        public Race(Greyhound[] greyhounds, int length )
        {
            Greyhounds = greyhounds;
            Length = length;
        }

        public Results Start()
        {
            
        }


    }

    class RaceGreyhound
    {
        // we're using this class to describe a greyhound on raceday so we're not altering its stats on the day
        // I guess we're using this to add a bunch of data to greyhound
        Greyhound Hound;
        public int CurrentSpeed { get; set; }
        public int CurrentStam { get; set; }
        public int SaltedTopSpeed { get; private set; }
        public int SaltedTenacity { get; private set; }
        public int SaltedAcceleration { get; private set; }

        public RaceGreyhound(Greyhound hound)
        {
            Hound = hound;
            CurrentSpeed = 0;
            CurrentStam = Hound.Stats.Stamina.StatValue + getSalt();
            SaltedTopSpeed = Hound.Stats.TopSpeed.StatValue + getSalt();
            SaltedTenacity = Hound.Stats.Tenacity.StatValue + getSalt();
            SaltedAcceleration = Hound.Stats.Tenacity.StatValue + getSalt();
        }

        // generating a modifier to make thing random
        private int getSalt()
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

    class Results
    {
        // todo, class to hold results
    }

}
