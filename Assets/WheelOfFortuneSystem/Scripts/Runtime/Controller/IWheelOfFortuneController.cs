namespace WheelOfFortuneSystem
{
    public interface IWheelOfFortuneController
    {
        IWheelOfFortuneModel Model { get; }
        IWheelOfFortuneView View { get; }
        ISpinButton SpinButton { get; }

        void Init();
        void Deinit();
    }
}