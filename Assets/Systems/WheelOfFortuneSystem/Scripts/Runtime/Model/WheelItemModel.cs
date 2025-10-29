using UnityEngine;

namespace WheelOfFortuneSystem
{
    public class WheelItemModel : IWheelItemModel
    {
        public int Amount { get; set; }
        public float Weight { get; set; }
        public string Id { get; set; }
        public bool IsDeadly { get; set; }
        public Sprite Icon { get; set; }
    }
}