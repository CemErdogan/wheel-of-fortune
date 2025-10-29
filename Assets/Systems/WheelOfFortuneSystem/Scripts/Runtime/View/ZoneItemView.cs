using CoreSystem;
using TMPro;
using UnityEngine;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class ZoneItemView : MonoBehaviour, IZoneItemView
    {
        [SerializeField, ValidateNotNull] private TextMeshProUGUI indexText;
        
        [Inject] private readonly ZoneAreaConfig _config;
        
        public void SetIndex(int index)
        {
            indexText.SetText(index.ToString());
            indexText.color = _config.GetColorByIndex(index);
        }

        private void OnValidate()
        {
            ValidationUtility.ValidateSerializedFields(this);
        }
    }
}