using System;
using SpaceShips.Ships;

namespace SpaceShips.AI
{
    internal class DestroyTargetTask
    {
        private readonly IShip _ship;
        private readonly IAttackTarget _target;
        
        internal event Action OnCompleted;
        internal event Action OnFailed;

        internal DestroyTargetTask(IShip ship, IAttackTarget target)
        {
            _ship = ship;
            _target = target;
            _target.OnDestroyed += Complete;
            _ship.OnDestroyed += Fail;
            ActivateWeapons();
        }

        private void Fail()
        {
            DeactivateWeapons();
            Dispose();
            OnFailed?.Invoke();
        }

        private void Complete()
        {
            DeactivateWeapons();
            Dispose();
            OnCompleted?.Invoke();
        }

        private void ActivateWeapons()
        {
            foreach (var ownWeapon in _ship.ShipStructure.Weapons)
                ownWeapon.Activate(_target, _ship.ShipStructure.Parameters);
        }

        private void DeactivateWeapons()
        {
            foreach (var weapon in _ship.ShipStructure.Weapons)
                weapon.Deactivate();
        }

        private void Dispose()
        {
            _ship.OnDestroyed -= Fail;
            _target.OnDestroyed -= Complete;
        }
    }
}