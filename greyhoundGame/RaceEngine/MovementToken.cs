namespace greyhoundGame.RaceEngine
{
    public class MovementToken
    {
        // the hound increment measures how fast a hound moves in relation to the fastest possible hound
        // smaller is faster as it moves more often

        private float HoundIncrement { get; set; }
        private RaceGreyhound Hound { get; set; }
        private double paceCount;
        private int paceTotal;


        public MovementToken(RaceGreyhound hound)
        {
            Hound = hound;
            HoundIncrement = Pace.FASTEST_POSSIBLE_HOUND / hound.CurrentSpeed;
            paceCount = 0;
            paceTotal = 0;
        }

        public void UpdatePace(int time)
        {
            paceCount++;
            paceTotal++;
            HoundIncrement = Pace.FASTEST_POSSIBLE_HOUND / Hound.CurrentSpeed;
            if (paceCount >= HoundIncrement)
            {
                paceCount -= HoundIncrement;
                Hound.UpdatePosition(time, paceTotal);
            }
        }

    }
}
