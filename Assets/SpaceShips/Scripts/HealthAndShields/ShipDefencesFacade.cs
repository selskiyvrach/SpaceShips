using System;
using SpaceShips.Parameters;
using SpaceShips.Ships;
using UnityEngine;

namespace SpaceShips.HealthAndShields
{
    internal class ShipDefencesFacade : IAttackTarget
    {
        private readonly IShipStructure _ship;
        
        private readonly DeathStater _deathStater;
        private readonly DamageAbsorber _health;
        private readonly DamageAbsorber _shield;
        private readonly ResourceRecharger _shieldRecharger;

        public event Action OnDestroyed
        {
            add => _deathStater.OnDestroyed += value;
            remove => _deathStater.OnDestroyed -= value;
        }

        public ShipDefencesFacade(IShipStructure ship)
        {
            _ship = ship;
            
            var parameters = ship.Parameters;
            var shieldCapacity = parameters.Get<HealthCapacity>().Value;
            var healthCapacity = parameters.Get<ShieldCapacity>().Value;
            
            _deathStater = new DeathStater();
            _health = new DamageAbsorber(capacity: healthCapacity, nextAbsorber: _deathStater);
            _shield = new DamageAbsorber(capacity: shieldCapacity, nextAbsorber: _health);

            var shieldRechargeRate = parameters.Get<ShieldRechargeRate>().Value;
            _shieldRecharger = new ResourceRecharger(_shield, ticksInterval: 1f, rechargeAmount: shieldRechargeRate);
            _shieldRecharger.Activate();
            OnDestroyed += () => _shieldRecharger.Deactivate();
        }

        public void TakeDamage(float amount)
        {
            _shield.TakeDamage(amount);
            Debug.Log($"Ship {_ship.GetHashCode()} has taken {amount} damage." +
                      $"\b Shield: {_shield.Current}/{_shield.Capacity}" +
                      $"\b Health: {_health.Current}/{_health.Capacity}");
        }
    }
}