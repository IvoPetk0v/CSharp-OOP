using System;
using System.Collections.Generic;
using System.Linq;
using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Repositories.Contracts;
using NavalVessels.Utilities.Messages;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IVessel> vessels;
        private readonly List<ICaptain> captains;

        public Controller()
        {
            this.vessels = new VesselRepository();
            this.captains = new List<ICaptain>();
        }

        public string HireCaptain(string fullName)
        {
            if (this.captains.Any(c => c.FullName == fullName))
            {
                return string.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }
            this.captains.Add(new Captain(fullName));
            return string.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            if (this.vessels.Models.Any(m => m.Name == name))
            {
                return string.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
            }

            if (vesselType == nameof(Submarine))
            {
                this.vessels.Add(new Submarine(name, mainWeaponCaliber, speed));
                return string.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber,
                    speed);
            }
            else if (vesselType == nameof(Battleship))
            {
                this.vessels.Add(new Battleship(name, mainWeaponCaliber, speed));
                return string.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber,
                    speed);
            }
            else
            {
                return OutputMessages.InvalidVesselType;
            }
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            if (captains.FirstOrDefault(c => c.FullName == selectedCaptainName) == null)
            {
                return string.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }

            if (vessels.FindByName(selectedVesselName) == null)
            {
                return string.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }
            else
            {
                if (vessels.FindByName(selectedVesselName).Captain != null)
                {
                    return string.Format(OutputMessages.VesselOccupied, selectedCaptainName);
                }
                else
                {
                    vessels.FindByName(selectedVesselName).Captain =
                        captains.First(c => c.FullName == selectedCaptainName);
                    captains.First(c => c.FullName == selectedCaptainName).AddVessel(vessels.FindByName(selectedVesselName));
                    return string.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
                }
            }

        }

        public string CaptainReport(string captainFullName)
        {
            string report = this.captains.First(c => c.FullName == captainFullName).Report();
            return report.ToString();
        }

        public string VesselReport(string vesselName)
        {
            return this.vessels.FindByName(vesselName).ToString();
        }

        public string ToggleSpecialMode(string vesselName)
        {
            if (this.vessels.FindByName(vesselName) == null)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }
            if (this.vessels.FindByName(vesselName) is Battleship)
            {
                Battleship ship = (Battleship)this.vessels.FindByName(vesselName);
                ship.ToggleSonarMode();
                return string.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
            } 
            else
            {
                Submarine ship = (Submarine)this.vessels.FindByName(vesselName);
                ship.ToggleSubmergeMode();
                return string.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
            }
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            var attacker = this.vessels.FindByName(attackingVesselName);
            var defender = this.vessels.FindByName(defendingVesselName);
            if (attacker == null)
            {
                return string.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }

            if (defender == null)
            {
                return string.Format(OutputMessages.VesselNotFound, defendingVesselName);
            }

            if (attacker.ArmorThickness == 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }

            if (defender.ArmorThickness == 0)
            {
                return string.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
            }
            attacker.Attack(defender);
            attacker.Captain.IncreaseCombatExperience();
            defender.Captain.IncreaseCombatExperience();
            return string.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName,
                defender.ArmorThickness.ToString());
        }

        public string ServiceVessel(string vesselName)
        {
            if (this.vessels.FindByName(vesselName) == null)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }
            this.vessels.FindByName(vesselName).RepairVessel();
            return string.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }
    }
}
