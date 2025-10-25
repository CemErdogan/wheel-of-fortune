using StateMachineSystem;

namespace WheelOfFortuneSystem
{
    public interface IWheelOfFortuneController
    {
        IWheelOfFortuneModel Model { get; }
        IWheelOfFortuneView View { get; }
        StateMachine StateMachine { get; }
        ISpinButton SpinButton { get; }

        void Init();
        void Deinit();
        void Tick();
    }
}