using StateMachineSystem;
using UnityEngine;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class WheelOfFortuneInstaller : MonoInstaller
    {
        [Header("Project References")]
        [SerializeField] private WheelOfFortuneConfig wheelOfFortuneConfig;
        [Space, Header("Local References")]
        [SerializeField] private GameObject spinButtonObject;
        [SerializeField] private GameObject wheelOfFortuneObject;
        [SerializeField] private GameObject wheelOfFortuneViewObject;
        [Space]
        [SerializeField] private Transform wheelItemParent;
        
        public const string WheelItemParentId = "WheelItemParentId";
        
        public override void InstallBindings()
        {
            Container.Bind<Transform>().WithId(WheelItemParentId).FromInstance(wheelItemParent).AsSingle();
            
            Container.Bind<WheelOfFortuneConfig>().FromInstance(wheelOfFortuneConfig).AsSingle();
            
            Container.Bind<ISpinButton>().To<SpinButton>().FromComponentOn(spinButtonObject).AsSingle();

            Container.Bind<StateMachine>().FromNew().AsSingle();
                
            Container.Bind<IWheelOfFortuneModel>().To<WheelOfFortuneModel>().FromNew().AsSingle();
            Container.Bind<IWheelOfFortuneView>().To<WheelOfFortuneView>().FromComponentOn(wheelOfFortuneViewObject).AsSingle();
            Container.Bind<IWheelOfFortuneController>().To<WheelOfFortuneController>().FromNew().AsSingle();
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
            
            if (wheelItemParent == null)
            {
                Debug.LogWarning("Wheel Item Parent is not assigned in the WheelOfFortuneInstaller.");
            }

            if (wheelOfFortuneConfig == null)
            {
                Debug.LogWarning("Wheel Of Fortune Config is not assigned in the WheelOfFortuneInstaller.");
            }
        }
    }
}