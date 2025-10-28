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
        private readonly List<WheelItemWeightData> _items = new();
        
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
            
            var items = new List<WheelItem>();
            var weights = new List<float>();

            foreach (var data in _items)
            {
                items.Add(data.Item);
                weights.Add(data.Weight);
            }

            var item = items.GetRandomWithLuck(weights);
            Assert.IsNotNull(item, "WheelItemManager: Selected random item is null!");
            
            var index = items.IndexOf(item);
            var angle = -(_angle * index) ;
            var targetRotation = Vector3.back * (angle + 2 * 360) ;
            
            return new RotationTargetData(item, targetRotation);
        }

        
        private void SetCallbacks(bool value)
        {
            if (value)
            {
                _signalBus.Subscribe<OnCreateItemsSignal>(CreateItemsCallback);
            }
            else
            {
                _signalBus.Unsubscribe<OnCreateItemsSignal>(CreateItemsCallback);
            }
        }
        
        private void CreateItemsCallback(OnCreateItemsSignal signal)
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
                _items.Add(new WheelItemWeightData(item, item.GetWeight()));
            }
        }
    }
}