using System;
using System.Collections.Generic;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class ZoneItemManager : IInitializable, IDisposable
    {
        [Inject] private readonly ZoneItem.Factory _itemFactory;
        [Inject] private readonly SignalBus _signalBus;
        [Inject] private readonly ZoneAreaConfig _zoneAreaConfig;
        
        private List<ZoneItem> _zoneItems = new();
        
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
                _signalBus.Subscribe<OnCreateZoneItemsSignal>(CreateItemsCallback);
            }
            else
            {
                _signalBus.Unsubscribe<OnCreateZoneItemsSignal>(CreateItemsCallback);
            }
        }
        
        private void CreateItemsCallback(OnCreateZoneItemsSignal signal)
        {
            var parent = signal.Parent;
            for (int i = 0; i < _zoneAreaConfig.ZoneItemCount; i++)
            {
                var item = _itemFactory.Create();
                item.Prepare(parent);
            }
        }
    }
}