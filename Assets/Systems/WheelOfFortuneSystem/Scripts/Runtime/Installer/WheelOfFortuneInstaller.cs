using StateMachineSystem;
using UnityEngine;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class WheelOfFortuneInstaller : MonoInstaller
    {
        [SerializeField] private GameObject spinButtonObject;
        [SerializeField] private GameObject wheelOfFortuneObject;
        [SerializeField] private GameObject wheelOfFortuneViewObject;
        
        public override void InstallBindings()
        {
            Container.Bind<ISpinButton>().To<SpinButton>().FromComponentOn(spinButtonObject).AsSingle();

            Container.Bind<StateMachine>().FromNew().AsSingle();
                
            Container.Bind<IWheelOfFortuneModel>().To<WheelOfFortuneModel>().FromNew().AsSingle();
            Container.Bind<IWheelOfFortuneView>().To<WheelOfFortuneView>().FromComponentOn(wheelOfFortuneViewObject).AsSingle();
            Container.Bind<IWheelOfFortuneController>().To<WheelOfFortuneController>().FromNew().AsSingle();
            
            Container.Bind<IWheelOfFortune>().To<WheelOfFortune>().FromComponentOn(wheelOfFortuneObject).AsSingle().NonLazy();
        }

        private void OnValidate()
        {
            if (spinButtonObject == null)
            {
                Debug.LogWarning("Spin Button Object is not assigned in the WheelOfFortuneInstaller.");
            }

            if (wheelOfFortuneViewObject == null)
            {
                Debug.LogWarning("Wheel Of Fortune View Object is not assigned in the WheelOfFortuneInstaller.");
            }

            if (wheelOfFortuneObject == null)
            {
                Debug.LogWarning("Wheel Of Fortune Object is not assigned in the WheelOfFortuneInstaller.");
            }
        }
    }
}