using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WheelOfFortuneSystem
{
    public class WheelOfFortuneView : MonoBehaviour, IWheelOfFortuneView
    {
        [SerializeField] private Transform rotateTransform;
        [SerializeField] private Image baseImage;
        [SerializeField] private TextMeshProUGUI headerText, infoText;
        
        public void PlaySpinAnimation(Vector3 targetRot, float duration, Ease ease, Action onComplete = null)
        {
            rotateTransform.DORotate(targetRot, duration, RotateMode.FastBeyond360)
                .SetRelative()
                .SetEase(ease)
                .OnComplete(() => onComplete?.Invoke())
                .SetLink(gameObject);
        }

        public void SetBaseImage(Sprite newImage)
        {
            baseImage.sprite = newImage;
        }

        public void SetHeaderText(string text)
        {
            headerText.SetText(text);
        }

        public void SetInfoText(string text)
        {
            infoText.SetText(text);
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
            
            if (headerText == null)
            {
                Debug.LogWarning("Header Text is not assigned in the WheelOfFortuneView.");
            }
            
            if (infoText == null)
            {
                Debug.LogWarning("Info Text is not assigned in the WheelOfFortuneView.");
            }
        }
    }
}