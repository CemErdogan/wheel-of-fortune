using System;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class WheelItemManager : IInitializable, IDisposable
    {
        [Inject] private readonly SignalBus _signalBus;
        [Inject] private readonly WheelItem.Factory _itemFactory;
        
        public void Initialize()
        {
            SetCallbacks(true);
        }

        public void Dispose()
        {
            SetCallbacks(false);
        }
        
        private void SetCallbacks(bool value)
        {
            if (value)
            {
                _signalBus.Subscribe<OnCreateItemsSignal>(CreateItemsCallback);
            }
            else
            {
                _signalBus.Unsubscribe<OnCreateItemsSignal>(CreateItemsCallback);
            }
        }
        
        private void CreateItemsCallback(OnCreateItemsSignal signal)
        {
            var count = signal.Count;
            var parent = signal.Parent;
            var multiplier = signal.Multiplier;
            var angle = 360 / count;
            for (int i = 0; i < count; i++)
            {
                var item = _itemFactory.Create();
                item.Prepare(parent, i * angle, multiplier);
            }
        }
    }
}