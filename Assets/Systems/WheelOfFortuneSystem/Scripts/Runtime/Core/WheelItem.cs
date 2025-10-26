using CoreSystem;
using UnityEngine;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class WheelItem : MonoBehaviour
    {
        [Inject] private readonly WheelItemConfig _config;
        [Inject] private readonly IWheelItemController _controller;

        public void Prepare(float angle)
        {
            _controller.Prepare(_config.WheelItemsData.GetRandom());
            transform.RotateAround(transform.position, Vector3.back, angle);
        }
        
        public class Factory : PlaceholderFactory<WheelItem> { }
    }
}