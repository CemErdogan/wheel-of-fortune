using CoreSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class ZoneItemView : MonoBehaviour, IZoneItemView
    {
        [SerializeField, ValidateNotNull] private TextMeshProUGUI indexText;
        [SerializeField, ValidateNotNull] private Image iconImage;
        
        [Inject] private readonly ZoneAreaConfig _config;
        
        public void SetIndex(int index)
        {
            indexText.SetText(index.ToString());
            iconImage.color = _config.GetColorByIndex(index);
        }

        private void OnValidate()
        {
            ValidationUtility.ValidateSerializedFields(this);
        }
    }
}