using UnityEngine;

namespace WheelOfFortuneSystem
{
    [CreateAssetMenu(fileName = "WheelItemContainer", menuName = "WheelOfFortuneSystem/WheelItemContainer")]
    public class WheelItemContainer : ScriptableObject
    {
        [field:SerializeField] public WheelItemData[] WheelItemsData { get; private set; }
    }
}