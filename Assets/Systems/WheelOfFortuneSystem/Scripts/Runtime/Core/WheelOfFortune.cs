using UnityEngine;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class WheelOfFortune : MonoBehaviour
    {
        [Inject] private readonly IWheelOfFortuneController _controller;

        private void Start()
        {
            _controller.Init();
        }

        private void OnDestroy()
        {
            _controller.Deinit();
        }

        private void Update()
        {
            _controller.Tick();
        }
    }
}