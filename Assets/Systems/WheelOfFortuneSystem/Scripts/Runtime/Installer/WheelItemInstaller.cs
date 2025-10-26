using UnityEngine;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class WheelItemInstaller : MonoInstaller
    { 
        [Header("Project References")]
        [SerializeField] private WheelItemConfig wheelItemConfig;
        [Space, Header("Local References")]
        [SerializeField] private GameObject wheelItemViewObject;

        public override void InstallBindings()
        {
            Container.Bind<WheelItemConfig>().FromInstance(wheelItemConfig).AsSingle();
            
            Container.Bind<WheelItemModel>().FromNew().AsSingle();
            Container.Bind<IWheelItemView>().To<WheelItemView>().FromComponentOn(wheelItemViewObject).AsSingle();
            Container.Bind<IWheelItemController>().To<WheelItemController>().AsSingle();
        }
    }
}