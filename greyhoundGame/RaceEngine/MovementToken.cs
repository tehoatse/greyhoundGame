namespace greyhoundGame.RaceEngine
{
    public class MovementToken
    {
        // the hound increment measures how fast a hound moves in relation to the fastest possible hound
        // smaller is faster as it moves more often

        private float HoundIncrement { get; set; }
        private RaceGreyhound Hound { get; set; }
        private double paceCount;


        public MovementToken(RaceGreyhound hound, float fastestHoundPace)
        {
            Hound = hound;
            HoundIncrement = Hound.GetIncrement(fastestHoundPace);
            paceCount = 0;

        }

        public void UpdatePace(int time)
        {
            paceCount++;
            if (paceCount >= HoundIncrement)
            {
                paceCount -= HoundIncrement;
                Hound.UpdatePosition(time);
            }
        }

    }
}
