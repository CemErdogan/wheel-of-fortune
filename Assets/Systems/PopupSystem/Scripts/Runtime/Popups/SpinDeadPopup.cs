using CoreSystem;
using DG.Tweening;
using UnityEngine;

namespace PopupSystem
{
    public class SpinDeadPopup : ScalePopup
    {
        [Header("Icon Settings")]
        [SerializeField, ValidateNotNull] private Transform iconTransform;
        [SerializeField] private float iconStartScale = 0f;
        [SerializeField] private float iconAppearDuration = 0.2f;
        [SerializeField] private Ease iconAppearEase = Ease.InSine;

        protected override void OnAppearSequenceExtended(Sequence seq)
        {
            iconTransform.localScale = Vector3.one * iconStartScale;
            seq.Append(iconTransform.DOScale(Vector3.one, iconAppearDuration).SetEase(iconAppearEase));
        }
    }
}