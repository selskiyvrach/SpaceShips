using SpaceShips.Ships;
using UnityEngine;

namespace SpaceShips.HealthAndShields
{
    internal class DamageAbsorber : IDamageable, IResource
    {
        private readonly IDamageable _nextAbsorber;
        public float Capacity { get; }

        public float Current { get; private set; }

        public DamageAbsorber(float capacity, IDamageable nextAbsorber = null)
        {
            Capacity = capacity;
            Current = Capacity;
            _nextAbsorber = nextAbsorber;
        }

        public void TakeDamage(float amount)
        {
            var overfill = amount - Current;
            Current -= amount;
            if (overfill <= 0)
                return;
            Current = 0;
            _nextAbsorber?.TakeDamage(overfill);
        }

        public void AddDeltaToCurrent(float delta) => 
            Current = Mathf.Clamp(Current + delta, 0, Capacity);
    }
}