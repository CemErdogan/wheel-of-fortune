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
        [Inject] private readonly WheelItemConfig _config;

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
        
        public void RequestNextWheelSpin(WheelOfFortuneBaseType baseType, int multiplier, bool skipDeadly)
        {
            var dataList = new List<WheelItemData>();
            for (int i = 0; i < _items.Count; i++)
            {
                var data = _config.GetRandomData(baseType, dataList, skipDeadly);
                dataList.Add(data);
            }
            
            for (int i = 0; i < _items.Count; i++)
            {
                _items[i].RePrepare(multiplier, dataList[i]);
            }
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
            
            var dataList = new List<WheelItemData>();
            for (int i = 0; i < count; i++)
            {
                var data = _config.GetRandomData(baseType, dataList);
                dataList.Add(data);
            }
            
            _angle = 360f / count;
            for (int i = 0; i < count; i++)
            {
                var item = _itemFactory.Create();
                item.Prepare(parent, i * _angle, multiplier, dataList[i]);
                _items.Add(item);
                _weights.Add(item.GetWeight());
            }
        }
    }
}