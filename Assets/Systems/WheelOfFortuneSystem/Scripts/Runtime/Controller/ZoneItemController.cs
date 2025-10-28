using Zenject;

namespace WheelOfFortuneSystem
{
    public class ZoneItemController : IZoneItemController
    {
        [Inject] public IZoneItemModel Model { get; }
        [Inject] public IZoneItemView View { get; }
        
        public void Prepare(int index)
        {
            Model.Index = index;
            View.SetIndex(index);
        }
    }
}