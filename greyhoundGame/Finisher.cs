namespace greyhoundGame
{
    class Finisher
    {

        private int _position;
        public RaceGreyhound Hound { get; private set; }
        public int Time { get; private set; }
        public int Position { 
            get => _position;
            set
            {
                _position = value;
                PositionName = GreyhoundStrings.GetOrdinalNumber(value);
            } 
        }
        public string PositionName { get; private set; }

        public Finisher(RaceGreyhound hound, int time)
        {
            Hound = hound;
            Time = time;
            Position = -1; 
        }

        public override string ToString()
        {
            return $"{Hound.Greyhound.Name} finished with a time of {Time}";
        }

    }
}
