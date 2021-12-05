using System;
using System.Collections.Generic;
using System.Text;

namespace greyhoundGame.RaceEngine
{
    internal class AllSeeingEye
    {
        public List<HoundRadar> Radar{ get; set; }

        public AllSeeingEye(RaceGreyhound[] hounds)
        {
            foreach(var hound in hounds)
            {
                Radar.Add(new HoundRadar(hound));
            }
        }
    }
}
