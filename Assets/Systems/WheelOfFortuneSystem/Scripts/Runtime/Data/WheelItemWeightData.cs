namespace WheelOfFortuneSystem
{
    public struct WheelItemWeightData
    {
        public readonly WheelItem Item;
        public readonly float Weight;
        
        public WheelItemWeightData(WheelItem item, float weight)
        {
            Item = item;
            Weight = weight;
        }
    }
}