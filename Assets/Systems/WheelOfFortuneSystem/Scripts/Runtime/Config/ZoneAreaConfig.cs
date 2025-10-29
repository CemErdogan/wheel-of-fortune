using UnityEngine;

namespace WheelOfFortuneSystem
{
    [CreateAssetMenu(fileName = "ZoneAreaConfig", menuName = "WheelOfFortuneSystem/Configs/ZoneAreaConfig", order = 0)]
    public class ZoneAreaConfig : ScriptableObject
    {
        [field:SerializeField] public WheelOfFortuneBaseType NormalZoneBaseType { get; private set; }
        [field:SerializeField] public Color NormalZoneColor { get; private set; } = Color.white;
        [field:SerializeField] public SpecialZoneTypeData [] SpecialZoneTypesData { get; private set; }
        
        public NextZoneData GetNextZoneData(int nextZoneIndex)
        {
            var match = FindSpecialZoneData(nextZoneIndex);
            var zoneType = match?.BaseType ?? NormalZoneBaseType;
            return new NextZoneData(zoneType);
        }

        public Color GetColorByIndex(int index)
        {
            var match = FindSpecialZoneData(index);
            return match?.Color ?? NormalZoneColor;
        }

        private SpecialZoneTypeData? FindSpecialZoneData(int index)
        {
            if (SpecialZoneTypesData == null || SpecialZoneTypesData.Length == 0)
                return null;

            for (int i = 0; i < SpecialZoneTypesData.Length; i++)
            {
                var special = SpecialZoneTypesData[i];
                if (special.RepeatCount > 0 && index % special.RepeatCount == 0)
                    return special;
            }

            return null;
        }
    }
}