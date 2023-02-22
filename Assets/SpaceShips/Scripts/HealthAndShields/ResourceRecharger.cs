using System;
using System.Threading;
using System.Threading.Tasks;

namespace SpaceShips.HealthAndShields
{
    internal class ResourceRecharger
    {
        private readonly IResource _resource;
        private readonly float _rechargeAmount;
        private readonly TimeSpan _ticksInterval;
        private CancellationTokenSource _cancellationTokenSource;

        public ResourceRecharger(IResource resource, float ticksInterval, float rechargeAmount)
        {
            _resource = resource;
            _rechargeAmount = rechargeAmount;
            _ticksInterval = TimeSpan.FromSeconds(ticksInterval);
        }

        internal async void Activate()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            while (true)
            {
                try
                {
                    await Task.Delay(_ticksInterval, _cancellationTokenSource.Token);
                }
                catch (TaskCanceledException e)
                {
                    break;
                }
                if (_cancellationTokenSource.IsCancellationRequested)
                    break;
                if(_resource.Current >= _resource.Capacity)
                    continue;
                _resource.AddDeltaToCurrent(_rechargeAmount);
            }
        }

        internal void Deactivate() => 
            _cancellationTokenSource?.Cancel();
    }
}