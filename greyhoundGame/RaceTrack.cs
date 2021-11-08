namespace greyhoundGame
{
    public class RaceTrack
    {
        // hey loook
        public static int TrackSpacing = 1;
        public static int FinishLineX = -1;
        public static int FinishLineY = -1;

        public int Width { get; private set; }
        public GreyhoundTrack Venue { get; private set; }
       
        public int Length { get; private set; }

        private RaceSquare[,] PhysicalRaceTrack;
        public RaceSquare FinishLine { get; private set; }

        public RaceTrack(GreyhoundTrack track, int length, int boxes)
        {
            Venue = track;   
            Width = boxes * TrackSpacing;
            Length = length;
            CreateTrack();
            FinishLine = new RaceSquare(FinishLineX, FinishLineY);
        }

        public RaceSquare GetSquare(int xCoord, int yCoord)
        {
            if (xCoord >= Length)
                return FinishLine;
            if (xCoord == FinishLineX || yCoord == FinishLineY)
                return FinishLine;
            return PhysicalRaceTrack[xCoord, yCoord];
        }

        private void CreateTrack()
        {
            PhysicalRaceTrack = new RaceSquare[Length, Width];

            for (int trackXCoord = 0; trackXCoord < Length; trackXCoord++)
            {
                for (int trackYCoord = 0; trackYCoord < Width; trackYCoord++)
                {
                    PhysicalRaceTrack[trackXCoord, trackYCoord] = new RaceSquare(trackXCoord, trackYCoord);
                }
            }
        }
    }
}
