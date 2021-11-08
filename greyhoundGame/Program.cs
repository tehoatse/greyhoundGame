using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

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
            Greyhound[] hounds = LoadHounds();
            
            //SaveHounds(hounds);

            GreyhoundTrack track = new GreyhoundTrack();
            track.TrackDescription = "A racetrack";
            track.TrackName = "TRACK";

            Race testRace = new Race(hounds, track, 500);

            Console.WriteLine(testRace.Start().ToString());

            //Race secondRace = new Race(hounds, 250);
            //Race thirdRace = new Race(hounds, 1000);

            //var results = testRace.Start();
            //LogText.Dump(results.ToString());
            //results = secondRace.Start();
            //LogText.Dump(results.ToString());
            //results = thirdRace.Start();
            //LogText.Dump(results.ToString());

            //Console.WriteLine(GreyhoundStrings.GetOrdinalNumber(10000000));

        }

        public static void SaveHounds(Greyhound[] hounds)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText("greyhoundlist.json", JsonSerializer.Serialize(hounds, options));

            //XmlSerializer write = new XmlSerializer(typeof(Greyhound[]));
            //FileStream file = System.IO.File.Create("greyhoundlist.xml");
            //write.Serialize(file, hounds);
        }

        public static Greyhound[] LoadHounds()
        {

            string jsonString = File.ReadAllText("greyhoundlist.json");
            Greyhound[] hounds = JsonSerializer.Deserialize<Greyhound[]>(jsonString);
            return hounds;

            //XmlSerializer reader = new XmlSerializer(typeof(Greyhound[]));
            //StreamReader file = new StreamReader("greyhoundlist.xml");
            //Greyhound[] hounds = (Greyhound[])reader.Deserialize(file);
            //file.Close();
            //return hounds;
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

    interface IMutator
    {
        void SetStats(Stat[] stat);
        Stat[] GetStats();
        bool IsMutatorGlobal();
    }
}
