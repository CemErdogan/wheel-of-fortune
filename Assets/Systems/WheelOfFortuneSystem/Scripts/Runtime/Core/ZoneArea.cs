using UnityEngine;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class ZoneArea : MonoBehaviour
    {
        [Inject] private readonly IZoneAreaController _controller;

        private void Start()
        {
            _controller.Init();
        }

        private void OnDestroy()
        {
            _controller.Deinit();
        }

        public class Factory : PlaceholderFactory<ZoneArea> { }
    }
}