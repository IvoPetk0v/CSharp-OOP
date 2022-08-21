using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace NavalVessels.Models.Contracts
{
    public class Battleship : Vessel, IBattleship
    {
        private const double InitialArmor = 300;
        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, InitialArmor)
        {
            this.SonarMode = false;
        }

        public bool SonarMode { get; private set; }
        public void ToggleSonarMode()
        {
            this.SonarMode = !this.SonarMode;
            if (this.SonarMode)
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
            else
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }
        }

        public override string ToString()
        {
            string result = this.SonarMode ? " *Sonar mode: ON" : " *Sonar mode: OFF";
            return base.ToString() +Environment.NewLine+result.ToString();
        }
    }
}
