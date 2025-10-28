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

        private void OnValidate()
        {
            ValidationUtility.ValidateSerializedFields(this);
        }
    }
}