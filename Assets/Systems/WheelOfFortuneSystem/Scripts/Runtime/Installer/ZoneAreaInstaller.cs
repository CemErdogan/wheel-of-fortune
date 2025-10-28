using Zenject;

namespace WheelOfFortuneSystem
{
    public class ZoneAreaInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IZoneAreaModel>().To<ZoneAreaModel>().AsSingle();
            Container.Bind<IZoneAreaView>().To<ZoneAreaView>().FromComponentInHierarchy().AsSingle();
            Container.Bind<IZoneAreaController>().To<ZoneAreaController>().AsSingle();
        }
    }
}