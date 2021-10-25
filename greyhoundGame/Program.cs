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
            Greyhound handsome = new Greyhound();
            Greyhound hanover = new Greyhound();
            Greyhound butter = new Greyhound();

            // good old all eighties!
            allEighties.Name = "Beef!";
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

            //Console.WriteLine(GreyhoundStrings.GetOrdinalNum(10000000));
            
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
}
