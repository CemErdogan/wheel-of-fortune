using UnityEngine;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class ZoneItem : MonoBehaviour
    {
        [Inject] private readonly IZoneItemController _zoneItemController;
        
        public class Factory : Zenject.PlaceholderFactory<ZoneItem> { }
    }
}