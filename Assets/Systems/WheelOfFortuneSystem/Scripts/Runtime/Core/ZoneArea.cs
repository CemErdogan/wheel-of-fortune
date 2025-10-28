using UnityEngine;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class ZoneArea : MonoBehaviour
    {
        [Inject] private readonly IZoneAreaController _zoneAreaController;
        
        public class Factory : PlaceholderFactory<ZoneArea> { }
    }
}