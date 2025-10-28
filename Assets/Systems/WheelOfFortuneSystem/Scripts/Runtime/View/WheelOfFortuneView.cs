using System;
using CoreSystem;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WheelOfFortuneSystem
{
    public class WheelOfFortuneView : MonoBehaviour, IWheelOfFortuneView
    {
        [SerializeField, ValidateNotNull] private Transform rotateTransform, itemParentTransform;
        [SerializeField, ValidateNotNull] private Image baseImage;
        [SerializeField, ValidateNotNull] private TextMeshProUGUI headerText, infoText;
        
        public void PlaySpinAnimation(Vector3 targetRot, float duration, Ease ease, Action onComplete = null)
        {
            rotateTransform.DORotate(targetRot, duration, RotateMode.FastBeyond360)
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

        public Transform GetItemParent()
        {
            return itemParentTransform;
        }

        private void OnValidate()
        {
            ValidationUtility.ValidateSerializedFields(this);
        }
    }
}