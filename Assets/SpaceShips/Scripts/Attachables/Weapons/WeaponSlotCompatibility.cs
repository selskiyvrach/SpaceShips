namespace SpaceShips.Attachables.Weapons
{
    internal class WeaponSlotCompatibility : ICompatibility
    {
        public bool Compatible(ISlot slot) => 
            slot is IWeaponSlot;
    }
}