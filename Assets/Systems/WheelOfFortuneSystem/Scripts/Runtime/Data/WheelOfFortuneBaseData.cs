using UnityEngine;

namespace WheelOfFortuneSystem
{
    [System.Serializable]
    public struct WheelOfFortuneBaseData
    {
        [field:SerializeField] public WheelOfFortuneBaseType BaseType { get; private set; }
        [field:SerializeField] public Sprite Image { get; private set; }
    }
}