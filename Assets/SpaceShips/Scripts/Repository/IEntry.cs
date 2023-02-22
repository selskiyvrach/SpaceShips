using SpaceShips.Attachables;

namespace SpaceShips.Repository
{
    internal interface IEntry
    {
        IAttachable Peek { get; }
        string Tip { get; }
        ModuleView ViewPrefab { get; }
        IAttachable Create();
    }
}