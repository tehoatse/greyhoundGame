namespace greyhoundGame.RaceEngine
{
    public class RaceTrack
    {
        
        public static int TrackSpacing = 1;
        public static int FinishLineX = -1;
        public static int FinishLineY = -1;

        
        public int TrackWidth { get; private set; }
        public GreyhoundTrack Venue { get; private set; }
       
        public int Length { get; private set; }

        private RaceSquare[,] PhysicalRaceTrack;
        public RaceSquare FinishLine { get; private set; }
        public RaceSquare OutOfBounds { get; private set; }

        public RaceTrack(GreyhoundTrack track, int length, int boxes)
        {
            Venue = track;   
            TrackWidth = boxes * TrackSpacing;
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
            if (yCoord < 0)
                return PhysicalRaceTrack[xCoord, 0];
            if (yCoord >= TrackWidth)
                return PhysicalRaceTrack[xCoord, TrackWidth - 1];
            return PhysicalRaceTrack[xCoord, yCoord];
        }

        public RaceSquare GetSquare(MovementDirection direction, RaceSquare currentSquare)
        {
            return direction switch
            {
                MovementDirection.UP => GetSquare(currentSquare.XCoord, currentSquare.YCoord + 1),
                MovementDirection.FORWARD => GetSquare(currentSquare.XCoord + 1, currentSquare.YCoord),
                MovementDirection.DOWN => GetSquare(currentSquare.XCoord, currentSquare.YCoord - 1),
                MovementDirection.BACKWARD => GetSquare(currentSquare.XCoord - 1, currentSquare.YCoord),
                _ => currentSquare,
            };
        }

        private void CreateTrack()
        {
            PhysicalRaceTrack = new RaceSquare[Length, TrackWidth];

            for (int trackXCoord = 0; trackXCoord < Length; trackXCoord++)
            {
                for (int trackYCoord = 0; trackYCoord < TrackWidth; trackYCoord++)
                {
                    PhysicalRaceTrack[trackXCoord, trackYCoord] = new RaceSquare(trackXCoord, trackYCoord);
                }
            }
        }
    }
}
