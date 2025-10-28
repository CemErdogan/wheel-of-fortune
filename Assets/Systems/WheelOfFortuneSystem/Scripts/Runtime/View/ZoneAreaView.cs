using CoreSystem;
using UnityEngine;
using UnityEngine.UI;

namespace WheelOfFortuneSystem
{
    public class ZoneAreaView : MonoBehaviour, IZoneAreaView
    {
        [SerializeField, ValidateNotNull] private ScrollRect scrollRect;
        [SerializeField, ValidateNotNull] private RectTransform viewportTransform, contentTransform;
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

        private void OnValidate()
        {
            ValidationUtility.ValidateSerializedFields(this);
        }
    }
}