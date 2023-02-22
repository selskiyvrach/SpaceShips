using System;
using SpaceShips.HealthAndShields;

namespace SpaceShips.Ships
{
    internal sealed class Ship : IShip
    {
        private readonly ShipDefencesFacade _shipDefencesFacade;
        
        public IShipStructure ShipStructure { get; }

        public event Action OnDestroyed
        {
            add => _shipDefencesFacade.OnDestroyed += value;
            remove => _shipDefencesFacade.OnDestroyed -= value;
        }

        public Ship(IShipStructure shipStructure)
        {
            ShipStructure = shipStructure;
            _shipDefencesFacade = new ShipDefencesFacade(shipStructure);
        }

        public void TakeDamage(float amount) => 
            _shipDefencesFacade.TakeDamage(amount);
    }
}