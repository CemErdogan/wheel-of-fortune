using System;
using DG.Tweening;
using UnityEngine;

namespace WheelOfFortuneSystem
{
    public class WheelOfFortuneView : MonoBehaviour, IWheelOfFortuneView
    {
        [SerializeField] private Transform rotateTransform;
        
        public void PlaySpinAnimation(Vector3 targetRot, float duration, Ease ease, Action onComplete = null)
        {
            rotateTransform.DORotate(targetRot, duration, RotateMode.FastBeyond360)
                .SetRelative()
                .SetEase(ease)
                .OnComplete(() => onComplete?.Invoke())
                .SetLink(gameObject);
        }
    }
}