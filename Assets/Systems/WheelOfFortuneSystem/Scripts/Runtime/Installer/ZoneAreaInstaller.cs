using UnityEngine;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class ZoneAreaInstaller : MonoInstaller
    {
        [SerializeField] private GameObject zoneAreaViewObject;
        
        public override void InstallBindings()
        {
            Container.Bind<IZoneAreaModel>().To<ZoneAreaModel>().FromNew().AsSingle();
            Container.Bind<IZoneAreaView>().To<ZoneAreaView>().FromComponentOn(zoneAreaViewObject).AsSingle();
            Container.Bind<IZoneAreaController>().To<ZoneAreaController>().FromNew().AsSingle();
        }

        private void OnValidate()
        {
            if (zoneAreaViewObject == null)
            {
                Debug.LogWarning($"{nameof(zoneAreaViewObject)} is not assigned in {nameof(ZoneAreaInstaller)}", this);
            }
        }
    }
}