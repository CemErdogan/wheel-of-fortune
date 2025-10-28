using UnityEngine;

namespace WheelOfFortuneSystem
{
    [System.Serializable]
    public struct SpecialZoneTypeData
    {
        [field:SerializeField] public string Id { get; private set; }
        [field:SerializeField] public int RepeatCount { get; private set; }
        [field: SerializeField] public WheelOfFortuneBaseType BaseType { get; private set; }

    }
}