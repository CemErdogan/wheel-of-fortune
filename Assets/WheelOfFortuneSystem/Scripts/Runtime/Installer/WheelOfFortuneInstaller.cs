using UnityEngine;
using Zenject;

namespace WheelOfFortuneSystem
{
    [RequireComponent(typeof(IWheelOfFortuneView))]
    public class WheelOfFortuneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IWheelOfFortuneModel>().To<WheelOfFortuneModel>().FromNew().AsSingle();
            Container.Bind<IWheelOfFortuneView>().To<WheelOfFortuneView>().FromComponentOn(gameObject).AsSingle();
            Container.Bind<IWheelOfFortuneController>().To<WheelOfFortuneController>().FromNew().AsSingle().NonLazy();
        }
    }
}