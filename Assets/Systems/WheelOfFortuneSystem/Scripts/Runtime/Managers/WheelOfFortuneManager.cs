using System;
using PopupSystem;
using UnityEngine;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class WheelOfFortuneManager : IInitializable, IDisposable
    {
        [Inject] private readonly WheelItemManager _wheelItemManager;
        [Inject] private readonly WheelOfFortune.Factory _wheelFactory;
        [Inject] private readonly LeaveButton.Factory _leaveButtonFactory;
        [Inject] private readonly SignalBus _signalBus;
        [Inject] private readonly WheelOfFortuneConfig _config;
        
        private WheelOfFortune _wheelOfFortune;
        private LeaveButton _leaveButton;
        
        public void Initialize()
        {
            SetCallbacks(true);
            _wheelOfFortune = _wheelFactory.Create();
            _leaveButton = _leaveButtonFactory.Create();
            _leaveButton.SetInteractable(false);
        }

        public void Dispose()
        {
            SetCallbacks(false);
        }
        
        private void SetCallbacks(bool value)
        {
            if (value)
            {
               _signalBus.Subscribe<OnSpinStartedSignal>(SpinStartedCallback);
               _signalBus.Subscribe<RequestNextWheelSpinSignal>(RequestNextWheelSpinCallback);
            }
            else
            {
                _signalBus.Unsubscribe<OnSpinStartedSignal>(SpinStartedCallback);
                _signalBus.Unsubscribe<RequestNextWheelSpinSignal>(RequestNextWheelSpinCallback);
            }
        }

        private void SpinStartedCallback(OnSpinStartedSignal signal)
        {
            var target = _wheelItemManager.GetRandomRotationTarget();
            var item = target.Item;
            var res = item.IsDeadly();
            _wheelOfFortune.DoSpin(target.TargetRotation, () =>
            {
                _signalBus.Fire(res
                    ? new OnRequestPopupShowSignal("SpinDead")
                    : new OnRequestPopupShowSignal("SpinReward", new SpinRewardPopupContext(item.GetAmount(), item.GetId(), item.GetIcon())));
                _signalBus.Fire<RequestNextZoneSignal>();
            });
            Debug.Log($"[WheelOfFortuneManager] Target: {item.name}, is deadly:{res}", item);
        }

        private void RequestNextWheelSpinCallback(RequestNextWheelSpinSignal signal)
        {
            var baseType = signal.NextZoneData.NextZoneType;
            var multiplier = _config.GetBaseMultiplier(baseType);
            
            _wheelOfFortune.RePrepare(baseType);
            _wheelItemManager.RequestNextWheelSpin(baseType, multiplier, signal.NextZoneData.IsSpecialZone);
            _leaveButton.SetInteractable(signal.NextZoneData.IsSpecialZone);
        }
    }
}