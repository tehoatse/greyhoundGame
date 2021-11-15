namespace greyhoundGame.RaceEngine
{
    public class RaceSquare
    {
        public bool HasGreyhound { get; set; }
        public int XCoord { get; set; }
        public int YCoord { get; set; }

        public RaceSquare(int xCoord, int yCoord)
        {
            XCoord = xCoord;
            YCoord = yCoord;
            HasGreyhound = false;
        }
    }
}
