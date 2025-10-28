using CoreSystem;
using StateMachineSystem;
using UnityEngine;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class WheelOfFortuneInstaller : MonoInstaller
    {
        [Space, Header("Local References")]
        [SerializeField, ValidateNotNull] private GameObject spinButtonObject;
        [SerializeField, ValidateNotNull] private GameObject wheelOfFortuneObject;
        [SerializeField, ValidateNotNull] private GameObject wheelOfFortuneViewObject;
        [Space]
        [SerializeField, ValidateNotNull] private Transform wheelItemParent;
        
        public override void InstallBindings()
        {
            Container.Bind<ISpinButton>().To<SpinButton>().FromComponentOn(spinButtonObject).AsSingle();

            Container.Bind<StateMachine>().FromNew().AsSingle();
                
            Container.Bind<IWheelOfFortuneModel>().To<WheelOfFortuneModel>().FromNew().AsSingle();
            Container.Bind<IWheelOfFortuneView>().To<WheelOfFortuneView>().FromComponentOn(wheelOfFortuneViewObject).AsSingle();
            Container.Bind<IWheelOfFortuneController>().To<WheelOfFortuneController>().FromNew().AsSingle();
        }
        
        private void OnValidate()
        {
            ValidationUtility.ValidateSerializedFields(this);
        }
    }
}