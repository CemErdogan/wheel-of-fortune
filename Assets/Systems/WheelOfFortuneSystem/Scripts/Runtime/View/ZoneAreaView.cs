using CoreSystem;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace WheelOfFortuneSystem
{
    public class ZoneAreaView : MonoBehaviour, IZoneAreaView
    {
        [SerializeField, ValidateNotNull] private ScrollRect scrollRect;
        [SerializeField, ValidateNotNull] private RectTransform viewportTransform, contentTransform, frameTransform;
        [SerializeField, ValidateNotNull] private HorizontalLayoutGroup horizontalLayoutGroup;
        
        public RectTransform GetItemParent()
        {
            return contentTransform;
        }

        public float GetViewPortWidth()
        {
            return viewportTransform.rect.width;
        }

        public float GetItemSpacing()
        {
            return horizontalLayoutGroup.spacing;
        }

        public void SnapTo(RectTransform target)
        {
            Canvas.ForceUpdateCanvases();
            LayoutRebuilder.ForceRebuildLayoutImmediate(contentTransform);

            var targetCenterWorld = target.TransformPoint(target.rect.center);
            var frameCenterWorld  = frameTransform.TransformPoint(frameTransform.rect.center);

            Vector2 targetCenterLocal = contentTransform.InverseTransformPoint(targetCenterWorld);
            Vector2 frameCenterLocal  = contentTransform.InverseTransformPoint(frameCenterWorld);

            var deltaX = frameCenterLocal.x - targetCenterLocal.x;
            var newPos = contentTransform.anchoredPosition + new Vector2(deltaX, 0f);
            var contentWidth  = contentTransform.rect.width;
            var viewportWidth = viewportTransform.rect.width;
            var minX = Mathf.Min(0f, viewportWidth - contentWidth);
            var maxX = 0f;
            newPos.x = Mathf.Clamp(newPos.x, minX, maxX);

            contentTransform
                .DOAnchorPos(newPos, 0.2f)
                .SetEase(Ease.OutCubic)
                .SetLink(gameObject);
        }


        private void OnValidate()
        {
            ValidationUtility.ValidateSerializedFields(this);
        }
    }
}