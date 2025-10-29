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
            Model.Weight = data.Weight;
            Model.Id = data.Id;
            Model.IsDeadly = data.IsDeadly;
            Model.Icon = data.Icon;
            View.Prepare(Model.Amount, data.Icon);
        }
    }
}