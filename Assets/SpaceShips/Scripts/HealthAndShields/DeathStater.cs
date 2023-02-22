using System;
using SpaceShips.Ships;

namespace SpaceShips.HealthAndShields
{
    internal class DeathStater : IDamageable, IDestroyedCallback
    {
        public event Action OnDestroyed;

        public void TakeDamage(float amount) => 
            OnDestroyed?.Invoke();
    }
}