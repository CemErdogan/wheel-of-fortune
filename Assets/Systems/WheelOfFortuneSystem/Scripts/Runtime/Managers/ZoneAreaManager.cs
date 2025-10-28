using System;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class ZoneAreaManager : IInitializable, IDisposable
    {
        [Inject] private readonly ZoneArea.Factory _zoneAreaFactory;

        private ZoneArea _zoneArea;
        
        public void Initialize()
        {
            _zoneArea = _zoneAreaFactory.Create();
        }

        public void Dispose()
        {
            
        }

        public float GetViewPortWidth()
        {
            return _zoneArea.GetViewPortWidth();
        }

        public float GetItemSpacing()
        {
            return _zoneArea.GetItemSpacing();
        }
    }
}