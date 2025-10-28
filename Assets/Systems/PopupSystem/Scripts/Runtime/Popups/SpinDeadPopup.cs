using CoreSystem;
using DG.Tweening;
using UnityEngine;

namespace PopupSystem.Popups
{
    public class SpinDeadPopup : Popup
    {
        [SerializeField, ValidateNotNull] private Transform iconTransform;
        [SerializeField] private float iconStartScale;
        [SerializeField] private float iconAppearDuration = 0.2f;
        [SerializeField] private Ease iconAppearEase = Ease.InSine;
        [Space]
        [SerializeField, ValidateNotNull] private Transform target;
        [Space]
        [SerializeField] private float appearStartScale = 1.1f;
        [SerializeField] private float appearTargetScale = 1f;
        [SerializeField] private float appearDuration = 0.28f;
        [SerializeField] private Ease appearEase = Ease.OutBack;
        [Space]
        [SerializeField] private float disappearTargetScale;
        [SerializeField] private float disappearDuration = 0.2f;
        [SerializeField] private Ease disappearEase = Ease.InBack;
        
        public override void Appear()
        {
            target.localScale = Vector3.one * appearStartScale;
            iconTransform.localScale = Vector3.one * iconStartScale;
            gameObject.SetActive(true);
            
            DOTween.Sequence()
                .Append(target.DOScale(Vector3.one * appearTargetScale, appearDuration).SetEase(appearEase))
                .Append(iconTransform.DOScale(Vector3.one, iconAppearDuration).SetEase(iconAppearEase))
                .SetLink(gameObject).SetLink(target.gameObject);
                
        }

        public override void Disappear()
        {
            target.DOScale(disappearTargetScale, disappearDuration)
                .SetEase(disappearEase)
                .OnComplete(() =>
                {
                    gameObject.SetActive(false);
                });
        }

        private void OnValidate()
        {
            ValidationUtility.ValidateSerializedFields(this);
        }
    }
}