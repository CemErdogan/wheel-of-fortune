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
        [Inject] private readonly WheelItem.Factory _itemFactory;
        
        public void Init()
        {
            Model.BaseType = WheelOfFortuneBaseType.Bronze;
            View.SetBaseVisual(_config.GetBaseSprite(Model.BaseType));
            
            SetCallbacks(true);
            PrepareFsm();
            PrepareWheelItems();
        }

        public void Deinit()
        {
            SetCallbacks(false);
        }

        public void Tick()
        {
            StateMachine.Tick();
        }

        private void SetCallbacks(bool value)
        {
            if (value)
            {
                SpinButton.OnButtonClick += SpinButtonClickedCallback;
            }
            else
            {
                SpinButton.OnButtonClick -= SpinButtonClickedCallback;
            }
        }
        
        private void PrepareFsm()
        {
            var idleState = new WheelOfFortuneIdleState();
            var processingState = new WheelOfFortuneProcessingState();
            
            StateMachine.AddTransition(idleState, processingState, new FuncPredicate(() => SpinButton.IsClicked));
            StateMachine.AddTransition(processingState, idleState, new FuncPredicate(() => !SpinButton.IsClicked));
            
            StateMachine.SetState(idleState);
        }
        
        private void PrepareWheelItems()
        {
            var angle = 360 / _config.WheelItemSize;
            for (int i = 0; i < _config.WheelItemSize; i++)
            {
                var item = _itemFactory.Create();
                item.Prepare(i * angle);
            }
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