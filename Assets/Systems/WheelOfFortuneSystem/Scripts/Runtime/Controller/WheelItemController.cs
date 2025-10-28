using Zenject;

namespace WheelOfFortuneSystem
{
    public class WheelItemController : IWheelItemController
    {
        [Inject] public IWheelItemView View { get; }
        [Inject] public IWheelItemModel Model { get; }
        
        public void Prepare(WheelItemData data, int multiplier)
        {
            Model.Amount = data.Amount * multiplier;
            View.Prepare(Model.Amount, data.Icon);
        }
    }
}