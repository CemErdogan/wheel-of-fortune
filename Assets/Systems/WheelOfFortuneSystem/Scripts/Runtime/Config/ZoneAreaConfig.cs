using UnityEngine;

namespace WheelOfFortuneSystem
{
    [CreateAssetMenu(fileName = "ZoneAreaConfig", menuName = "WheelOfFortuneSystem/Configs/ZoneAreaConfig", order = 0)]
    public class ZoneAreaConfig : ScriptableObject
    {
        [field:SerializeField] public WheelOfFortuneBaseType NormalZoneBaseType { get; private set; }
        [field:SerializeField] public SpecialZoneTypeData [] SpecialZoneTypesData { get; private set; }
    }
}