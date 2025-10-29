using CoreSystem;
using DG.Tweening;
using UnityEngine;

namespace PopupSystem
{
    public abstract class ScalePopup : Popup
    {
        [Header("Target Settings")]
        [SerializeField, ValidateNotNull] protected Transform target;

        [Header("Appear Settings")]
        [SerializeField] protected float appearStartScale = 1.1f;
        [SerializeField] protected float appearTargetScale = 1f;
        [SerializeField] protected float appearDuration = 0.28f;
        [SerializeField] protected Ease appearEase = Ease.OutBack;

        [Header("Disappear Settings")]
        [SerializeField] protected float disappearTargetScale = 0.9f;
        [SerializeField] protected float disappearDuration = 0.2f;
        [SerializeField] protected Ease disappearEase = Ease.InBack;

        public override void Appear()
        {
            target.localScale = Vector3.one * appearStartScale;
            gameObject.SetActive(true);

            var seq = DOTween.Sequence()
                .Append(target.DOScale(Vector3.one * appearTargetScale, appearDuration).SetEase(appearEase));

            OnAppearSequenceExtended(seq);
            seq.SetLink(gameObject).SetLink(target.gameObject);
        }

        public override void Disappear()
        {
            target.DOScale(disappearTargetScale, disappearDuration)
                .SetEase(disappearEase)
                .OnComplete(() => gameObject.SetActive(false));
        }

        protected virtual void OnAppearSequenceExtended(Sequence seq) { }

        protected virtual void OnValidate()
        {
            ValidationUtility.ValidateSerializedFields(this);
        }
    }
}