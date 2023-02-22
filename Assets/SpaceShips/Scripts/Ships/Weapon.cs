using System;
using System.Threading;
using System.Threading.Tasks;
using SpaceShips.Parameters;

namespace SpaceShips.Ships
{
    internal class Weapon : IWeapon
    {
        private readonly float _damage;
        private readonly float _baseCooldown;

        private CancellationTokenSource _cancellationTokenSource;
        
        public Weapon(float damage, float cooldown)
        {
            _damage = damage;
            _baseCooldown = cooldown;
        }

        public async void Activate(IDamageable target, Parameters.Parameters parameters)
        {
            var cooldown = TimeSpan.FromSeconds(_baseCooldown * parameters.Get<WeaponsReloadTimeFactor>().Value);
            _cancellationTokenSource = new CancellationTokenSource();
            var token = _cancellationTokenSource.Token;
            while (true)
            {
                if(token.IsCancellationRequested)
                    break;
                try
                {
                    await Task.Delay(cooldown, token);
                }
                catch (TaskCanceledException exception)
                {
                    break;
                }
                target.TakeDamage(_damage);
            }
        }

        public void Deactivate() 
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource = null;
        }
    }
}