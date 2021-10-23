using System;
using System.IO;
using System.Collections.Generic;

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
            Greyhound handsome = new Greyhound();
            Greyhound hanover = new Greyhound();
            Greyhound butter = new Greyhound();

            // good old all eighties!
            allEighties.Name = "Beef";
            allEighties.Age = 2;
            allEighties.Stats.Stamina.StatValue = 80;
            allEighties.Stats.TopSpeed.StatValue = 80;
            allEighties.Stats.Acceleration.StatValue = 80;
            allEighties.Stats.Tenacity.StatValue = 80;

            allEighties2.Name = "Kevin the Dog";
            allEighties2.Age = 2;
            allEighties2.Stats.Stamina.StatValue = 80;
            allEighties2.Stats.TopSpeed.StatValue = 80;
            allEighties2.Stats.Acceleration.StatValue = 80;
            allEighties2.Stats.Tenacity.StatValue = 80;

            handsome.Name = "Handsome Stranger";
            handsome.Age = 2;
            handsome.Stats.Stamina.StatValue = 70;
            handsome.Stats.TopSpeed.StatValue = 70;
            handsome.Stats.Acceleration.StatValue = 70;
            handsome.Stats.Tenacity.StatValue = 70;

            hanover.Name = "Gargano";
            hanover.Age = 2;
            hanover.Stats.Stamina.StatValue = 70;
            hanover.Stats.TopSpeed.StatValue = 70;
            hanover.Stats.Acceleration.StatValue = 75;
            hanover.Stats.Tenacity.StatValue = 60;

            butter.Name = "Butter";
            butter.Age = 2;
            butter.Stats.Stamina.StatValue = 60;
            butter.Stats.TopSpeed.StatValue = 60;
            butter.Stats.Acceleration.StatValue = 60;
            butter.Stats.Tenacity.StatValue = 60;

            Greyhound[] hounds = { allEighties, allEighties2, handsome, hanover, butter };

            Race testRace = new Race(hounds);
            Race secondRace = new Race(hounds, 250);
            Race thirdRace = new Race(hounds, 1000);
            
            var results = testRace.Start();
            LogText.Dump(results.ToString());
            results = secondRace.Start();
            LogText.Dump(results.ToString());
            results = thirdRace.Start();
            LogText.Dump(results.ToString());
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
    class Results
    {
        // the greyhounds in the race
        public RaceGreyhound[] Form { get; set; } // not used?

        private List<Finisher> finishers = new List<Finisher>();

        public Results()
        {
            // it's empty!
        }

        public void AddFinisher(RaceGreyhound hound, int time)
        {
            finishers.Add(new Finisher(hound, time));
            finishers[finishers.Count-1].Position = finishers.Count; // this is stupid
        }

        public override string ToString()
        {
            string outString = "And the positions are decided!\n";

            foreach (var finisher in finishers)
            {
                outString += finisher.PositionName + "! ";
                outString += finisher.ToString() + "\n";
            }
            return outString;
        }
    }

    
    class Finisher
    {
        // basic class to hold finishing information for the results

        private int _position;
        public RaceGreyhound Hound { get; private set; }
        public int Time { get; private set; }
        public int Position { 
            get => _position;
            set
            {
                _position = value;
                PositionName = GreyhoundStrings.GetOrdinalName(value);
            } 
        }
        public string PositionName { get; private set; }

        public Finisher(RaceGreyhound hound, int time)
        {
            Hound = hound;
            Time = time;
        }

        public override string ToString()
        {
            return $"{Hound.Greyhound.Name} finished with a time of {Time}";
        }

    }
}
