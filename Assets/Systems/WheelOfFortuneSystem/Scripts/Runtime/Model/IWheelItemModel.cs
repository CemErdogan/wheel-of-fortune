namespace WheelOfFortuneSystem
{
    public interface IWheelItemModel
    {
        int Amount { get; set; }
        float Weight { get; set; }
        string Id { get; set; }
        bool IsDeadly { get; set; }
    }
}