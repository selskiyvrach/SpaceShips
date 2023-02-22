namespace SpaceShips.HealthAndShields
{
    internal interface IResource : IReadOnlyResource
    {
        void AddDeltaToCurrent(float delta);
    }

    internal interface IReadOnlyResource
    {
        float Capacity {get;}
        float Current { get; }
    }
}