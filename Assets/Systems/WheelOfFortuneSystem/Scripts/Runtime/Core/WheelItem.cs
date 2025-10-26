using UnityEngine;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class WheelItem : MonoBehaviour
    {
        [Inject] private readonly IWheelItemController _controller;

        public void Prepare(WheelItemData data)
        {
            _controller.Prepare(data);
        }
        
        public class Factory : PlaceholderFactory<WheelItem> { }
    }
}