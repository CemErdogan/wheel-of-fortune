using UnityEngine;

namespace WheelOfFortuneSystem
{
    [CreateAssetMenu(fileName = "WheelItemConfig", menuName = "WheelOfFortuneSystem/Configs/WheelItemConfig")]
    public class WheelItemConfig : ScriptableObject
    {
        [field:SerializeField] public WheelItemData[] WheelItemsData { get; private set; }
    }
}