using UnityEngine;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class WheelItem : MonoBehaviour
    {
        [Inject] private readonly IWheelItemController _controller;
        [Inject] private readonly IWheelItemModel _model;

        public void Prepare(Transform parent, float angle, int multiplier, WheelItemData data)
        {
            transform.SetParent(parent);
            _controller.Prepare(data, multiplier);
            transform.RotateAround(transform.position, Vector3.back, angle);
            gameObject.name = $"WheelItem_{_model.Id}";
        }

        public void RePrepare(int multiplier, WheelItemData data)
        {
            _controller.Prepare(data, multiplier);
            gameObject.name = $"WheelItem_{_model.Id}";
        }
        
        public float GetWeight()
        {
            return _model.Weight;
        }
        
        public bool IsDeadly()
        {
            return _model.IsDeadly;
        }
        
        public string GetId()
        {
            return _model.Id;
        }
        
        public int GetAmount()
        {
            return _model.Amount;
        }

        public Sprite GetIcon()
        {
            return _model.Icon;
        }
        
        public class Factory : PlaceholderFactory<WheelItem> { }
    }
}