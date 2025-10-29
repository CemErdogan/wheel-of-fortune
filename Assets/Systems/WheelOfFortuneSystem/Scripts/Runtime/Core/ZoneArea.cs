using UnityEngine;
using UnityEngine.Assertions;
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
            Assert.IsNotNull(_view, "ZoneArea View is null!");
            return _view.GetViewPortWidth();
        }

        public float GetItemSpacing()
        {
            Assert.IsNotNull(_view, "ZoneArea View is null!");
            return _view.GetItemSpacing();
        }

        public int GetCurrentZon()
        {
            Assert.IsNotNull(_model, "ZoneArea Model is null!");
            return _model.CurrentZoneIndex;
        }

        public void SetZoneIndex(int nextZoneIndex)
        {
            Assert.IsNotNull(_model, "ZoneArea Model is null!");
            
            while (_model.CurrentZoneIndex < nextZoneIndex)
            {
                StepForwardOnce();
            }
        }

        private void StepForwardOnce()
        {
            _model.CurrentZoneIndex++;

            var leftMost = _zoneItems[0];
            for (int i = 1; i < _zoneItems.Length; i++)
            {
                _zoneItems[i - 1] = _zoneItems[i];
            }
            _zoneItems[^1] = leftMost;

            var rt = leftMost.transform;
            rt.SetAsLastSibling();

            var newIndexForRightMost = _model.CurrentZoneIndex + _zoneItems.Length - 1;
            leftMost.SetIndex(newIndexForRightMost + 1);
        }

        public class Factory : PlaceholderFactory<ZoneArea> { }
    }
}
