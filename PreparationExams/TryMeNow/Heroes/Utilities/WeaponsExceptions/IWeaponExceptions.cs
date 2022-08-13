
namespace Heroes.Utilities.WeaponsExceptions
{
    public interface IWeaponExceptions
    {

        public string DurabilityCantBeBelow0()
        {
            return "Durability cannot be below 0.";
        }
        public string NameCantBeNullOrWhitespace()
        {
            return "Weapon type cannot be null or empty.";
        }
    }
}
