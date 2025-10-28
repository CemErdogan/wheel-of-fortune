using System;
using UnityEngine;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class WheelOfFortuneManager : IInitializable, IDisposable
    {
        [Inject] private readonly WheelItemManager wheelItemManager;
        [Inject] private readonly WheelOfFortune.Factory _wheelFactory;
        [Inject] private readonly SignalBus _signalBus;
        
        private WheelOfFortune _wheelOfFortune;
        
        public void Initialize()
        {
            SetCallbacks(true);
            _wheelOfFortune = _wheelFactory.Create();
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
            }
            else
            {
                _signalBus.Unsubscribe<OnSpinStartedSignal>(SpinStartedCallback);
            }
        }

        private void SpinStartedCallback(OnSpinStartedSignal signal)
        {
            var target = wheelItemManager.GetRandomRotationTarget();
            var item = target.Item;
            var res = item.IsDeadly();
            _wheelOfFortune.DoSpin(target.TargetRotation, () =>
            {
                if (res)
                {
                    _signalBus.Fire<OnSpinDeadSignal>();
                }
            });
            Debug.Log($"[WheelOfFortuneManager] Target: {item.name}, res:{item.IsDeadly()}", item);
        }
    }
}