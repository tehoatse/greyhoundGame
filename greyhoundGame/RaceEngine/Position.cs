namespace greyhoundGame.RaceEngine
{
    public class Position
    {
        public int Number { get; set; }
        public string Ordinal { get; set; }
        public string OrdinalText { get; set; }

        public Position(int position)
        {
            Number = position;
            Ordinal = GreyhoundStrings.GetOrdinalNumber(position);
            OrdinalText = GreyhoundStrings.GetOrdinalName(position);
        }
    }
}
