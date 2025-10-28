using Zenject;

namespace WheelOfFortuneSystem
{
    public class ZoneAreaController : IZoneAreaController
    {
        [Inject] public IZoneAreaModel Model { get; }
        [Inject] public IZoneAreaView View { get; }
        
        [Inject] private readonly SignalBus _signalBus;
        
        public void Init()
        {
            _signalBus.Fire(new OnCreateZoneItemsSignal(View.GetItemParent()));
        }

        public void Deinit()
        {
            
        }
    }
}