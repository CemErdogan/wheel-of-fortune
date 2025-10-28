using Zenject;

namespace WheelOfFortuneSystem
{
    public class ZoneAreaController : IZoneAreaController
    {
        [Inject] public IZoneAreaModel Model { get; }
        [Inject] public IZoneAreaView View { get; }
    }
}