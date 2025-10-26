using DG.Tweening;
using UnityEngine;

namespace WheelOfFortuneSystem
{
    [CreateAssetMenu(fileName = "WheelOfFortuneConfig", menuName = "WheelOfFortuneSystem/Configs/WheelOfFortuneConfig")]
    public class WheelOfFortuneConfig : ScriptableObject
    {
        [field:SerializeField, Tooltip("x:min, y:max")] public Vector2 SpinDuration { get; private set; } = new(3f, 5f);
        [field:SerializeField] public Ease SpinEase { get; private set; } = Ease.OutBack;
        [field:SerializeField] public int WheelItemSize { get; private set; } = 8;
        [field:SerializeField] public WheelOfFortuneBaseData[] BaseData { get; private set; }

        public Sprite GetBaseSprite(WheelOfFortuneBaseType baseType)
        {
            foreach (var baseData in BaseData)
            {
                if (baseData.BaseType == baseType)
                    return baseData.Image;
            }

            Debug.LogError($"[WheelOfFortuneConfig] Base sprite for type {baseType} not found. Returning null.");
            return null;
        }

        public int GetBaseMultiplier(WheelOfFortuneBaseType baseType)
        {
            foreach (var baseData in BaseData)
            {
                if (baseData.BaseType == baseType)
                    return baseData.Multiplier;
            }

            Debug.LogError("[WheelOfFortuneConfig] Default base multiplier not found. Returning 1.");
            return 1;
        }
    }
}