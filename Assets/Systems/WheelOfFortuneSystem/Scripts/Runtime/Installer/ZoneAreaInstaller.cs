using CoreSystem;
using UnityEngine;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class ZoneAreaInstaller : MonoInstaller
    {
        [Header("Local References")]
        [SerializeField, ValidateNotNull] private GameObject zoneAreaViewObject;
        
        public override void InstallBindings()
        {
            Container.Bind<IZoneAreaModel>().To<ZoneAreaModel>().FromNew().AsSingle();
            Container.Bind<IZoneAreaView>().To<ZoneAreaView>().FromComponentOn(zoneAreaViewObject).AsSingle();
            Container.Bind<IZoneAreaController>().To<ZoneAreaController>().FromNew().AsSingle();
        }
        
        private void OnValidate()
        {
            ValidationUtility.ValidateSerializedFields(this);
        }
    }
}