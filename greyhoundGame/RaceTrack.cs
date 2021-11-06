namespace greyhoundGame
{
    public class RaceTrack
    {
        // hey loook
        public static int TrackSpacing = 3;
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

        public RaceSquare getCoordinates(int xCoord, int yCoord)
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

            for (int trackLength = 0; trackLength < Length; trackLength++)
            {
                for (int trackWidth = 0; trackWidth < Width; trackWidth++)
                {
                    PhysicalRaceTrack[trackLength, trackWidth] = new RaceSquare(trackLength, trackWidth);
                }
            }
        }
    }
}
