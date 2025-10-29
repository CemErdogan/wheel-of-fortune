using System;
using CoreSystem;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PopupSystem
{
    public class SpinRewardPopup : ScalePopup
    {
        [Header("Spin Settings")]
        [SerializeField, ValidateNotNull] private Transform spinTransform;
        [SerializeField] private float spinDuration = 4f;
        
        [Header("Reward Settings")]
        [SerializeField, ValidateNotNull] private Image iconImage;
        [SerializeField, ValidateNotNull] private TextMeshProUGUI headerText;
        [SerializeField, ValidateNotNull] private TextMeshProUGUI infoText;
        [SerializeField] private float autoCloseDelay = 2f;
            
        public override void Prepare(IPopupContext context)
        {
            base.Prepare(context);
            if (context is not SpinRewardPopupContext data)
            {
                throw new ArgumentException("Invalid context type. Expected SpinRewardPopupContext.", nameof(context));
            }

            iconImage.sprite = data.Icon;
            headerText.SetText(data.Id.Replace('_', ' ').ToUpperInvariant());
            infoText.SetText($"x{data.Amount}");
        }

        protected override void OnAppearSequenceExtended(Sequence seq)
        {
            spinTransform.DORotate(new Vector3(0f, 0f, 360f), spinDuration, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                .SetRelative()
                .SetLoops(-1, LoopType.Incremental)
                .SetLink(gameObject);
            seq.AppendInterval(autoCloseDelay);
            seq.AppendCallback(Disappear);
        }
    }
}