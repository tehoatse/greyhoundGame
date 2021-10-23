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
