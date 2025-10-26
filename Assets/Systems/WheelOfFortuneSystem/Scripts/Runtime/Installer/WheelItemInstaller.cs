using UnityEngine;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class WheelItemInstaller : MonoInstaller
    { 
        [SerializeField] private GameObject wheelItemViewObject;

        public override void InstallBindings()
        {
            Container.Bind<WheelItemModel>().FromNew().AsSingle();
            Container.Bind<IWheelItemView>().To<WheelItemView>().FromComponentOn(wheelItemViewObject).AsSingle();
            Container.Bind<IWheelItemController>().To<WheelItemController>().AsSingle();
        }
    }
}