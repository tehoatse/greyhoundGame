using System;

namespace greyhoundGame
{ 
    [Serializable()]
    public class Greyhound
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

}
