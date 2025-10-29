namespace WheelOfFortuneSystem
{
    public struct NextZoneData
    {
        public readonly WheelOfFortuneBaseType NextZoneType;
        public readonly bool IsSpecialZone;
        
        public NextZoneData(WheelOfFortuneBaseType nextZoneType, bool isSpecialZone)
        {
            NextZoneType = nextZoneType;
            IsSpecialZone = isSpecialZone;
        }
    }
}