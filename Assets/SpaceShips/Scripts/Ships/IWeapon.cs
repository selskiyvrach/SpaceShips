namespace SpaceShips.Ships
{
    internal interface IWeapon
    {
        void Activate(IDamageable target, Parameters.Parameters parameters);
        void Deactivate();
    }
}