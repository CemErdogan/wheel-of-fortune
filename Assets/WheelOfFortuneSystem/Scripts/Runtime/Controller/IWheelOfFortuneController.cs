namespace WheelOfFortuneSystem
{
    public interface IWheelOfFortuneController
    {
        IWheelOfFortuneModel Model { get; }
        IWheelOfFortuneView View { get; }
    }
}