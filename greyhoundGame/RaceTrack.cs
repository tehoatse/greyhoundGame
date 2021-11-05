namespace greyhoundGame
{
    public class RaceTrack
    {
        public int Width { get; private set; }
        public GreyhoundTrack Venue { get; private set; }
        
        public int Length { get; private set; }
        private RaceSquare[,] PhysicalRaceTrack;

        public RaceTrack(GreyhoundTrack track, int length, int boxes)
        {
            Venue = track;   
            Width = boxes *3;
            Length = length;
            CreateTrack();
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
