namespace SpaceShips.Attachables.Modules
{
    internal class ModuleSlotCompatibility : ICompatibility
    {
        public bool Compatible(ISlot slot) => 
            slot is IModuleSlot;
    }
}