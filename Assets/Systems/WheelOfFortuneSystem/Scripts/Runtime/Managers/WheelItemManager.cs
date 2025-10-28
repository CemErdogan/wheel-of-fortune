using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class WheelItemManager : IInitializable, IDisposable
    {
        [Inject] private readonly SignalBus _signalBus;
        [Inject] private readonly WheelItem.Factory _itemFactory;

        private float _angle;
        private readonly List<WheelItem> _items = new();
        private readonly List<float> _weights = new();
        
        public void Initialize()
        {
            SetCallbacks(true);
        }

        public void Dispose()
        {
            SetCallbacks(false);
        }

        public RotationTargetData GetRandomRotationTarget()
        {
            Assert.IsNotNull(_items, "WheelItemManager: Items list is null!");
            Assert.IsTrue(_items.Count > 0, "WheelItemManager: Items list is empty!");
            
            var item = _items.GetRandomWithLuck(_weights);
            Assert.IsNotNull(item, "WheelItemManager: Selected random item is null!");
            
            var index = _items.IndexOf(item);
            var angle = -(_angle * index) ;
            var targetRotation = Vector3.back * (angle + 360);
            
            return new RotationTargetData(item, targetRotation);
        }

        
        private void SetCallbacks(bool value)
        {
            if (value)
            {
                _signalBus.Subscribe<OnCreateWheelItemsSignal>(CreateItemsCallback);
            }
            else
            {
                _signalBus.Unsubscribe<OnCreateWheelItemsSignal>(CreateItemsCallback);
            }
        }
        
        private void CreateItemsCallback(OnCreateWheelItemsSignal signal)
        {
            var count = signal.Count;
            var parent = signal.Parent;
            var multiplier = signal.Multiplier;
            var baseType = signal.BaseType;
            
            _angle = 360f / count;
            for (int i = 0; i < count; i++)
            {
                var item = _itemFactory.Create();
                item.Prepare(parent, i * _angle, multiplier, baseType);
                _items.Add(item);
                _weights.Add(item.GetWeight());
            }
        }
    }
}