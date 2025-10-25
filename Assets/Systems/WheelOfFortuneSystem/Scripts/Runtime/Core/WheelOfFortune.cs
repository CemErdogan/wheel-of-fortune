using UnityEngine;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class WheelOfFortune : MonoBehaviour, IWheelOfFortune
    {
        [Inject] public IWheelOfFortuneController Controller { get; }

        private void Start()
        {
            Controller.Init();
        }

        private void OnDestroy()
        {
            Controller.Deinit();
        }

        private void Update()
        {
            Controller.Tick();
        }
    }
}