namespace greyhoundGame
{
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
                PositionName = GreyhoundStrings.GetOrdinalNum(value);
            } 
        }
        public string PositionName { get; private set; }

        public Finisher(RaceGreyhound hound, int time)
        {
            Hound = hound;
            Time = time;
            Position = 1; // needs a position for things to work
        }

        public override string ToString()
        {
            return $"{Hound.Greyhound.Name} finished with a time of {Time}";
        }

    }
}
