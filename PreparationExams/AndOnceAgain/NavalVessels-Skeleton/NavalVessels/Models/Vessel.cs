using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private readonly double initialArmor;
        private string name;
        private ICaptain captain;
        private ICollection<string> targets;
        private double armorThickness;

        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            this.Name = name;
            this.MainWeaponCaliber = mainWeaponCaliber;
            this.Speed = speed;
            this.ArmorThickness = armorThickness;
            this.initialArmor = armorThickness;
            this.targets = new List<string>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidVesselName);
                }

                this.name = value;
            }
        }

        public ICaptain Captain
        {
            get => this.captain;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
                }

                this.captain = value;
            }
        }

        public double ArmorThickness
        {
            get => this.armorThickness;
            set
            {
                if (value < 0)
                {
                    this.armorThickness = 0;
                }
                else
                {
                    this.armorThickness = value;
                }
            }
        }

        public double MainWeaponCaliber { get; protected set; }
        public double Speed { get; protected set; }
        public ICollection<string> Targets
        {
            get => this.targets.ToImmutableList();
        }
        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }

            target.ArmorThickness -= this.MainWeaponCaliber;
            this.targets.Add(target.Name);
        }

        public void RepairVessel()
        {
            this.armorThickness = initialArmor;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Armor thickness: {this.ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {this.MainWeaponCaliber}");
            sb.AppendLine($" *Speed: {this.Speed} knots");
            sb.Append(" *Targets: ");
            string targetResult = this.targets.Count >= 1 ? string.Join(", ", this.targets) : "None";
            sb.AppendLine(targetResult);
            return sb.ToString().TrimEnd();
        }
    }
}
