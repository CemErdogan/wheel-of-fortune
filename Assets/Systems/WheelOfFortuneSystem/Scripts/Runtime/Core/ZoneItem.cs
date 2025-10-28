using UnityEngine;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class ZoneItem : MonoBehaviour
    {
        [Inject] private readonly IZoneItemController _zoneItemController;
        
        public void Prepare(RectTransform parent, int index)
        {
            transform.SetParent(parent);
            _zoneItemController.Prepare(index);
        }

        public class Factory : PlaceholderFactory<ZoneItem>
        {
            public float GetWidth()
            {
                var tempItem = Create();
                var width = tempItem.GetComponent<RectTransform>().rect.width;
                Destroy(tempItem.gameObject);
                return width;
            }
        }
    }
}