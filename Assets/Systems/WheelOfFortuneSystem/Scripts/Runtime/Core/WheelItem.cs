using UnityEngine;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class WheelItem : MonoBehaviour
    {
        [Inject] private readonly WheelItemConfig _config;
        [Inject] private readonly IWheelItemController _controller;

        public void Prepare(Transform parent, float angle, int multiplier, WheelOfFortuneBaseType baseType)
        {
            transform.SetParent(parent);
            _controller.Prepare(_config.GetRandomData(baseType), multiplier);
            transform.RotateAround(transform.position, Vector3.back, angle);
        }
        
        public class Factory : PlaceholderFactory<WheelItem> { }
    }
}