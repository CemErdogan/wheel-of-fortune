using DG.Tweening;
using UnityEngine;

namespace WheelOfFortuneSystem
{
    [CreateAssetMenu(fileName = "WheelOfFortuneConfig", menuName = "WheelOfFortuneSystem/Config")]
    public class WheelOfFortuneConfig : ScriptableObject
    {
        [field:SerializeField, Tooltip("x:min, y:max")] public Vector2 SpinDuration { get; private set; } = new(3f, 5f);
        [field:SerializeField] public Ease SpinEase { get; private set; } = Ease.OutBack;
        [field:SerializeField] public int WheelItemSize { get; private set; } = 8;
    }
}