using System;
using System.Collections.Generic;
using System.Text;
using NavalVessels.Models.Contracts;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private const double InitialArmor = 200;

        public Submarine(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, InitialArmor)
        {
            this.SubmergeMode = false;
        }

        public bool SubmergeMode { get; private set; }
        public void ToggleSubmergeMode()
        {
            this.SubmergeMode = !this.SubmergeMode;
            if (SubmergeMode)
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
            }
            else
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
            }
        }

        public override string ToString()
        {
            string result = this.SubmergeMode ? " *Submerge mode: ON" : " *Submerge mode: OFF";
            return base.ToString() + Environment.NewLine + result.ToString().TrimEnd();
        }
    }
}
