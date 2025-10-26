using Zenject;

namespace WheelOfFortuneSystem
{
    public class WheelItemController : IWheelItemController
    {
        [Inject] public IWheelItemView View { get; }
        [Inject] public WheelItemModel Model { get; }
        
        public void Prepare(WheelItemData data)
        {
            Model.Data = data;
            View.Prepare(data.Amount, data.Icon);
        }
    }
}