namespace WheelOfFortuneSystem
{
    public class WheelOfFortuneController : IWheelOfFortuneController
    {
        public IWheelOfFortuneModel Model { get; }
        public IWheelOfFortuneView View { get; }

        public WheelOfFortuneController(IWheelOfFortuneModel model, IWheelOfFortuneView view)
        {
            Model = model;
            View = view;
        }
    }
}