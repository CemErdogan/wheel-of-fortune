using StateMachineSystem;
using UnityEngine;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class WheelOfFortuneController : IWheelOfFortuneController
    {
        [Inject] public IWheelOfFortuneModel Model { get; }
        [Inject] public IWheelOfFortuneView View { get; }
        [Inject] public StateMachine StateMachine { get; }
        [Inject] public ISpinButton SpinButton { get; }
        
        [Inject] private readonly WheelOfFortuneConfig _config;
        
        public void Init()
        {
            SpinButton.OnButtonClick += SpinButtonClickedCallback;
            PrepareFsm();
        }

        public void Deinit()
        {
            SpinButton.OnButtonClick -= SpinButtonClickedCallback;
        }

        public void Tick()
        {
            StateMachine.Tick();
        }
        
        private void PrepareFsm()
        {
            var idleState = new WheelOfFortuneIdleState();
            var processingState = new WheelOfFortuneProcessingState();
            
            StateMachine.AddTransition(idleState, processingState, new FuncPredicate(() => SpinButton.IsClicked));
            StateMachine.AddTransition(processingState, idleState, new FuncPredicate(() => !SpinButton.IsClicked));
            
            StateMachine.SetState(idleState);
        }

        private void SpinButtonClickedCallback()
        {
            SpinButton.SetInteractable(false);
            var testVal = new Vector3(0, 0, 120);
            var duration = Random.Range(_config.SpinDuration.x, _config.SpinDuration.y);
            View.PlaySpinAnimation(testVal, duration, _config.SpinEase, ()=>
            {
                SpinButton.SetInteractable(true);
            });
        }
    }
}