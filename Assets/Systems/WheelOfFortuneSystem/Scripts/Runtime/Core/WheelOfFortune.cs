using UnityEngine;
using UnityEngine.Assertions;
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
        
        public void DoSpin(Vector3 targetTargetRotation)
        {
            Assert.IsNotNull(_controller, "[WheelOfFortune] WheelOfFortuneController is null!");
            _controller.DoSpin(targetTargetRotation);
        }
        
        public class Factory : PlaceholderFactory<WheelOfFortune> { }
    }
}