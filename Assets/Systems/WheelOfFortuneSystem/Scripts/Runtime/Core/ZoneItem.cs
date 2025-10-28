using UnityEngine;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class ZoneItem : MonoBehaviour
    {
        [Inject] private readonly IZoneItemController _zoneItemController;
        
        public void Prepare(RectTransform parent)
        {
            transform.SetParent(parent);
        }
        
        public class Factory : Zenject.PlaceholderFactory<ZoneItem> { }
    }
}