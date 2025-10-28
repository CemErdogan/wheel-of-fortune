using Zenject;

namespace WheelOfFortuneSystem
{
    public class ZoneItemController : IZoneItemController
    {
        [Inject] public IZoneItemModel Model { get; }
        [Inject] public IZoneItemView View { get; }
    }
}