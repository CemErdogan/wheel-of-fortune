using CoreSystem;
using UnityEngine;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class ZoneItemInstaller : MonoInstaller
    {
        [SerializeField, ValidateNotNull] private GameObject zoneItemViewObject;
        
        public override void InstallBindings()
        {
            Container.Bind<IZoneItemView>().To<ZoneItemView>().FromComponentOn(zoneItemViewObject).AsSingle();
            Container.Bind<IZoneItemModel>().To<ZoneItemModel>().FromNew().AsSingle();
            Container.Bind<IZoneItemController>().To<ZoneItemController>().FromNew().AsSingle();
        }
        
        private void OnValidate()
        {
            ValidationUtility.ValidateSerializedFields(this);
        }
    }
}