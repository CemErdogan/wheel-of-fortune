namespace WheelOfFortuneSystem
{
    public interface IWheelItemController
    {
        IWheelItemView View { get; }
        WheelItemModel Model { get; }
        
        void Prepare(WheelItemData data);
    }
}