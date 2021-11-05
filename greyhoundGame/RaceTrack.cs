namespace greyhoundGame
{
    public class RaceTrack
    {

        public static int TrackSpacing = 3;

        public int Width { get; private set; }
        public GreyhoundTrack Venue { get; private set; }
        
        public int Length { get; private set; }
        private RaceSquare[,] PhysicalRaceTrack;

        public RaceTrack(GreyhoundTrack track, int length, int boxes)
        {
            Venue = track;   
            Width = boxes * TrackSpacing;
            Length = length;
            CreateTrack();
        }

        public RaceSquare getCoordinates(int xCoord, int yCoord)
        {
            return PhysicalRaceTrack[xCoord, yCoord];
        }

        private void CreateTrack()
        {
            PhysicalRaceTrack = new RaceSquare[Length, Width];
            for (int trackLength = 0; trackLength > Length; trackLength++)
            {
                for (int trackWidth = 0; trackWidth > Width; trackWidth++)
                {
                    PhysicalRaceTrack[trackLength, trackWidth] = new RaceSquare(trackLength, trackWidth);
                }
            }
        }
    }
}
