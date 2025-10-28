using CoreSystem;
using UnityEngine;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class WheelItemInstaller : MonoInstaller
    { 
        [Space, Header("Local References")]
        [SerializeField, ValidateNotNull] private GameObject wheelItemViewObject;

        public override void InstallBindings()
        {
            Container.Bind<IWheelItemModel>().To<WheelItemModel>().FromNew().AsSingle();
            Container.Bind<IWheelItemView>().To<WheelItemView>().FromComponentOn(wheelItemViewObject).AsSingle();
            Container.Bind<IWheelItemController>().To<WheelItemController>().AsSingle();
        }
        
        private void OnValidate()
        {
            ValidationUtility.ValidateSerializedFields(this);
        }
    }
}