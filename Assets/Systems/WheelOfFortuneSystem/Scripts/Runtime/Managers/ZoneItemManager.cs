using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class ZoneItemManager : IInitializable, IDisposable
    {
        [Inject] private readonly ZoneItem.Factory _itemFactory;
        [Inject] private readonly SignalBus _signalBus;
        [Inject] private readonly ZoneAreaConfig _zoneAreaConfig;
        [Inject] private readonly ZoneAreaManager _zoneAreaManager;
        
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
            var itemCount = Mathf.CeilToInt(_zoneAreaManager.GetViewPortWidth() / (_itemFactory.GetWidth() + _zoneAreaManager.GetItemSpacing()));
            for (int i = 0; i < itemCount; i++)
            {
                var item = _itemFactory.Create();
                item.Prepare(parent, i + 1);
            }
        }
    }
}