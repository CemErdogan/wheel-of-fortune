using Zenject;

namespace CoreSystem
{
    public class CoreInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
        }
    }
}
