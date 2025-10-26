using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace WheelOfFortuneSystem
{
    public class WheelOfFortuneView : MonoBehaviour, IWheelOfFortuneView
    {
        [SerializeField] private Transform rotateTransform;
        [SerializeField] private Image baseImage;
        
        public void PlaySpinAnimation(Vector3 targetRot, float duration, Ease ease, Action onComplete = null)
        {
            rotateTransform.DORotate(targetRot, duration, RotateMode.FastBeyond360)
                .SetRelative()
                .SetEase(ease)
                .OnComplete(() => onComplete?.Invoke())
                .SetLink(gameObject);
        }

        public void SetBaseVisual(Sprite newImage)
        {
            baseImage.sprite = newImage;
        }

        private void OnValidate()
        {
            if (rotateTransform == null)
            {
                Debug.LogWarning("Rotate Transform is not assigned in the WheelOfFortuneView.");
            }

            if (baseImage == null)
            {
                Debug.LogWarning("Base Image is not assigned in the WheelOfFortuneView.");
            }
        }
    }
}