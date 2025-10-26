using StateMachineSystem;
using UnityEngine;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class WheelOfFortuneInstaller : MonoInstaller
    {
        [Header("Project References")]
        [SerializeField] private WheelOfFortuneConfig wheelOfFortuneConfig;
        [SerializeField] private WheelItemContainer wheelItemContainer;
        [Space]
        [SerializeField] private WheelItem wheelItemPrefab;
        [Space, Header("Local References")]
        [SerializeField] private GameObject spinButtonObject;
        [SerializeField] private GameObject wheelOfFortuneObject;
        [SerializeField] private GameObject wheelOfFortuneViewObject;
        [Space]
        [SerializeField] private Transform wheelItemParent;
        
        public override void InstallBindings()
        {
            Container.Bind<WheelOfFortuneConfig>().FromInstance(wheelOfFortuneConfig).AsSingle();
            Container.Bind<WheelItemContainer>().FromInstance(wheelItemContainer).AsSingle();

            Container.BindFactory<WheelItem, WheelItem.Factory>()
                .FromComponentInNewPrefab(wheelItemPrefab)
                .UnderTransform(wheelItemParent)
                .AsSingle();
            
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
        }
    }
}