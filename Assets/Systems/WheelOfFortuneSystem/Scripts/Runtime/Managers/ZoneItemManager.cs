using System;
using System.Collections.Generic;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class ZoneItemManager : IInitializable, IDisposable
    {
        [Inject] private readonly ZoneItem.Factory _zoneItemFactory;
        
        private List<ZoneItem> _zoneItems = new();
        
        public void Initialize()
        {
            
        }

        public void Dispose()
        {
            
        }
    }
}