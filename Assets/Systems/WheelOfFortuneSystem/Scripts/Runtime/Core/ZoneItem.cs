using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class ZoneItem : MonoBehaviour
    {
        [Inject] private readonly IZoneItemController _controller;
        [Inject] private readonly IZoneItemView _view;
        
        public void Prepare(RectTransform parent, int index)
        {
            Assert.IsNotNull(_controller, "ZoneItem Controller is null!");
            
            transform.SetParent(parent);
            _controller.Prepare(index);
        }
        
        public void SetIndex(int newIndexForRightMost)
        {
            Assert.IsNotNull(_view, "ZoneItem View is null!");
            
            _view.SetIndex(newIndexForRightMost);
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