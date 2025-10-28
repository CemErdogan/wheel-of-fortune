using UnityEngine;

namespace WheelOfFortuneSystem
{
    [CreateAssetMenu(fileName = "ZoneAreaConfig", menuName = "WheelOfFortuneSystem/Configs/ZoneAreaConfig", order = 0)]
    public class ZoneAreaConfig : ScriptableObject
    {
        [field:SerializeField] public int ZoneItemCount { get; private set; } = 6;
    }
}