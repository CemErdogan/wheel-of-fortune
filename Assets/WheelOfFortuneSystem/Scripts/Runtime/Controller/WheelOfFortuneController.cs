using UnityEngine;

namespace WheelOfFortuneSystem
{
    public class WheelOfFortuneController : IWheelOfFortuneController
    {
        public IWheelOfFortuneModel Model { get; }
        public IWheelOfFortuneView View { get; }
        public ISpinButton SpinButton { get; }

        public WheelOfFortuneController(IWheelOfFortuneModel model, IWheelOfFortuneView view, ISpinButton spinButton)
        {
            Model = model;
            View = view;
            SpinButton = spinButton;
        }
        
        public void Init()
        {
            SpinButton.OnButtonClick += SpinButtonClickedCallback;
        }

        public void Deinit()
        {
            SpinButton.OnButtonClick -= SpinButtonClickedCallback;
        }
        
        private void SpinButtonClickedCallback()
        {
        }
    }
}