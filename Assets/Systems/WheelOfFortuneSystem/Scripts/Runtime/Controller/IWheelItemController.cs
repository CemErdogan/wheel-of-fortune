namespace WheelOfFortuneSystem
{
    public interface IWheelItemController
    {
        IWheelItemView View { get; }
        IWheelItemModel Model { get; }
        
        void Prepare(WheelItemData data, int multiplier);
    }
}