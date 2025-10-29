using UnityEngine;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class ZoneArea : MonoBehaviour
    {
        [Inject] private readonly IZoneAreaController _controller;
        [Inject] private readonly IZoneAreaView _view;
        [Inject] private readonly IZoneAreaModel _model;
        
        private ZoneItem[] _zoneItems;

        private void Start()
        {
            _controller.Init();
        }
        
        public void SetZoneItems(ZoneItem[] zoneItems)
        {
            _zoneItems = zoneItems;
        }

        public float GetViewPortWidth()
        {
            return _view.GetViewPortWidth();
        }

        public float GetItemSpacing()
        {
            return _view.GetItemSpacing();
        }
        
        public int GetCurrentZon()
        {
            return _model.CurrentZoneIndex;
        }
        
        public void SetZoneIndex(int currentZoneIndex)
        {
            var targetItem = _zoneItems[currentZoneIndex % _zoneItems.Length];
            _controller.SetZoneIndex(currentZoneIndex, targetItem.GetComponent<RectTransform>());
        }
        
        public class Factory : PlaceholderFactory<ZoneArea> { }
    }
}