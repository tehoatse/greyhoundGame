using System;
using System.Collections.Generic;
using System.Text;

namespace greyhoundGame.RaceEngine
{
    internal class AllSeeingEye
    {
        private Marshal _marshal;
        public List<HoundRadar> Radar { get; set; }
        
        public AllSeeingEye(Marshal marshal)
        {
            _marshal = marshal;
            Radar = new List<HoundRadar>();

            foreach(var hound in _marshal.GetHounds())
            {
                Radar.Add(new HoundRadar(hound, _marshal));
            }
        }

        public void RefreshAllRadars()
        {
            foreach(var radar in Radar)
            {
                radar.RefreshRadar();
            }
        }


    }
}
