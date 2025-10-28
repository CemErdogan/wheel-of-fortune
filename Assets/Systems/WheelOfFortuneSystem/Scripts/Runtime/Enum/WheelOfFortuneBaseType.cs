using System;

namespace WheelOfFortuneSystem
{
    [Flags]
    public enum WheelOfFortuneBaseType
    {
        Bronze = 1 << 0,
        Silver = 1 << 1,
        Gold = 1 << 2, 
    }
}