using UnityEngine;

namespace WheelOfFortuneSystem
{
    public struct RotationTargetData
    {
        public readonly WheelItem Item;
        public readonly Vector3 TargetRotation;
        
        public RotationTargetData(WheelItem item, Vector3 targetRotation)
        {
            Item = item;
            TargetRotation = targetRotation;
        }
    }
}