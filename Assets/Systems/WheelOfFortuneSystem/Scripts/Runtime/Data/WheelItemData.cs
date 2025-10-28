using UnityEngine;

namespace WheelOfFortuneSystem
{
    [System.Serializable]
    public struct WheelItemData
    {
        [field:SerializeField] public Sprite Icon { get; private set; }
        [field:SerializeField] public string Id { get; private set; }
        [field:SerializeField] public int Amount { get; private set; }
        [field: SerializeField, Tooltip("Set which base types this item can appear in")] public WheelOfFortuneBaseType AppearType { get; private set; }
        [field:SerializeField, Range(0, 100)] public int Weight { get; private set; }
    }
}