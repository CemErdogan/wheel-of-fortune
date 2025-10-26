using UnityEngine;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class WheelItem : MonoBehaviour
    {
        [Inject] private readonly IWheelItemController _controller;

        public void Prepare(WheelItemData data, float angle)
        {
            _controller.Prepare(data);
            transform.RotateAround(transform.position, Vector3.back, angle);
        }
        
        public class Factory : PlaceholderFactory<WheelItem> { }
    }
}