using System;
using UnityEngine;
using UnityEngine.UI;

namespace WheelOfFortuneSystem
{
    public class ZoneAreaView : MonoBehaviour, IZoneAreaView
    {
        [SerializeField] private ScrollRect scrollRect;
        [SerializeField] private RectTransform viewportTransform, contentPanelTransform;
        [SerializeField] private HorizontalLayoutGroup horizontalLayoutGroup;

        private void OnValidate()
        {
            if (scrollRect == null)
            {
                Debug.LogWarning($"{nameof(scrollRect)} is not assigned in {nameof(ZoneAreaView)}", this);
            }
            
            if (viewportTransform == null)
            {
                Debug.LogWarning($"{nameof(viewportTransform)} is not assigned in {nameof(ZoneAreaView)}", this);
            }
            
            if (contentPanelTransform == null)
            {
                Debug.LogWarning($"{nameof(contentPanelTransform)} is not assigned in {nameof(ZoneAreaView)}", this);
            }
        }
    }
}