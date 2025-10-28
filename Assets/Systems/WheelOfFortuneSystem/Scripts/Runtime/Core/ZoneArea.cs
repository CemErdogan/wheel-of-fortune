using UnityEngine;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class ZoneArea : MonoBehaviour
    {
        [Inject] private readonly IZoneAreaController _controller;
        [Inject] private readonly IZoneAreaView _view;

        private void Start()
        {
            _controller.Init();
        }

        private void OnDestroy()
        {
            _controller.Deinit();
        }
        
        public float GetViewPortWidth()
        {
            return _view.GetViewPortWidth();
        }

        public float GetItemSpacing()
        {
            return _view.GetItemSpacing();
        }
        
        public class Factory : PlaceholderFactory<ZoneArea> { }
    }
}