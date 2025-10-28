using System;
using StateMachineSystem;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace WheelOfFortuneSystem
{
    public class WheelOfFortuneController : IWheelOfFortuneController
    {
        [Inject] public IWheelOfFortuneModel Model { get; }
        [Inject] public IWheelOfFortuneView View { get; }
        [Inject] public StateMachine StateMachine { get; }
        [Inject] public ISpinButton SpinButton { get; }
        [Inject] private readonly SignalBus _signalBus;
        [Inject] private readonly WheelOfFortuneConfig _config;
        
        public void Init()
        {
            Model.BaseType = WheelOfFortuneBaseType.Bronze;
            var multiplier = _config.GetBaseMultiplier(Model.BaseType);
            View.SetBaseImage(_config.GetBaseSprite(Model.BaseType));
            View.SetHeaderText($"{Model.BaseType} SPIN");
            View.SetInfoText($"Up To x{multiplier} Rewards");
            
            SetCallbacks(true);
            PrepareFsm();
            
            _signalBus.Fire(new OnCreateWheelItemsSignal(_config.WheelItemSize, View.GetItemParent(), multiplier, Model.BaseType));
        }

        public void Deinit()
        {
            SetCallbacks(false);
        }

        public void Tick()
        {
            StateMachine.Tick();
        }

        public void DoSpin(Vector3 targetRot, Action onComplete = null)
        {
            var duration = Random.Range(_config.SpinDuration.x, _config.SpinDuration.y);
            View.PlaySpinAnimation(targetRot, duration, _config.SpinEase, ()=>
            {
                onComplete?.Invoke();
                SpinButton.SetInteractable(true);
            });
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

        private void SpinButtonClickedCallback()
        {
            _signalBus.Fire<OnSpinStartedSignal>();
            SpinButton.SetInteractable(false);
        }
    }
}