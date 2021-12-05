using System;
using System.Collections.Generic;
using System.Text;

namespace greyhoundGame.RaceEngine
{
    internal class AllSeeingEye
    {
        public List<HoundRadar> Radar{ get; set; }
        private Marshal _marshal;

        public AllSeeingEye(Marshal marshal)
        {
            _marshal = marshal;

            foreach(var hound in _marshal.getHounds())
            {
                Radar.Add(new HoundRadar(hound));
            }
        }
    }
}
