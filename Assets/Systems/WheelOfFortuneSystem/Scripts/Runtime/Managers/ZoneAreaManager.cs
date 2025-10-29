using System;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class ZoneAreaManager : IInitializable, IDisposable
    {
        [Inject] private readonly ZoneArea.Factory _zoneAreaFactory;
        [Inject] private readonly SignalBus _signalBus;

        private ZoneArea _zoneArea;
        
        public void Initialize()
        {
            SetCallbacks(true);
            _zoneArea = _zoneAreaFactory.Create();
        }

        public void Dispose()
        {
            SetCallbacks(false);
        }
        
        public void SetZoneItems(ZoneItem[] zoneItems)
        {
            _zoneArea.SetZoneItems(zoneItems);
            _zoneArea.SetZoneIndex(0);
        }

        public float GetViewPortWidth()
        {
            return _zoneArea.GetViewPortWidth();
        }

        public float GetItemSpacing()
        {
            return _zoneArea.GetItemSpacing();
        }
        
        private void SetCallbacks(bool value)
        {
            if (value)
            {
                _signalBus.Subscribe<RequestNextZoneSignal>(NextZoneRequestedCallback);
            }
            else
            {
                _signalBus.Unsubscribe<RequestNextZoneSignal>(NextZoneRequestedCallback);
            }
        }
        
        private void NextZoneRequestedCallback(RequestNextZoneSignal signal)
        {
            var next = _zoneArea.GetCurrentZon() + 1;
            _zoneArea.SetZoneIndex(next);
        }
    }
}