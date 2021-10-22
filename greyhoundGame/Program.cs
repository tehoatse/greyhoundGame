using System;
using System.IO;

namespace greyhoundGame
{
    class LogText
    {
        public static void Dump(string outDump)
        {
            File.AppendAllText("greyhoundlog.txt", outDump);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("We're gunna make a greyhound with all 80s!");
            Console.WriteLine("Building dat greyhound!");
            Greyhound allEighties = new Greyhound();
            Greyhound allEighties2 = new Greyhound();

            // good old all eighties!
            allEighties.Name = "All Eighties";
            allEighties.Age = 2;
            allEighties.Stats.Stamina.StatValue = 80;
            allEighties.Stats.TopSpeed.StatValue = 80;
            allEighties.Stats.Acceleration.StatValue = 80;
            allEighties.Stats.Tenacity.StatValue = 80;

            allEighties2.Name = "All Eighties the Second";
            allEighties2.Age = 2;
            allEighties2.Stats.Stamina.StatValue = 80;
            allEighties2.Stats.TopSpeed.StatValue = 80;
            allEighties2.Stats.Acceleration.StatValue = 80;
            allEighties2.Stats.Tenacity.StatValue = 80;

            Greyhound[] hounds = { allEighties, allEighties2 };

            Race testRace = new Race(hounds);
            testRace.Start();
        }
    }
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

    class Results
    {
        // todo, class to hold results
    }

}
