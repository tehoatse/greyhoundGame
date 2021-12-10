using System;
using System.Collections.Generic;
using System.Text;

namespace greyhoundGame.RaceEngine
{
    internal class AllSeeingEye
    {
        private Marshal _marshal;
        public List<HoundRadar> Radar{ get; set; }
        
        public AllSeeingEye(Marshal marshal)
        {
            _marshal = marshal;

            foreach(var hound in _marshal.getHounds())
            {
                Radar.Add(new HoundRadar(hound, _marshal));
            }
        }

        public void RefreshRadar()
        {
            foreach(var radar in Radar)
            {
                RefreshRadar();
            }
        }


    }
}
