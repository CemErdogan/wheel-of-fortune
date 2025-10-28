using CoreSystem;
using TMPro;
using UnityEngine;

namespace WheelOfFortuneSystem
{
    public class ZoneItemView : MonoBehaviour, IZoneItemView
    {
        [SerializeField, ValidateNotNull] private TextMeshProUGUI indexText;
        
        public void SetIndex(int index)
        {
            indexText.SetText(index.ToString());
        }

        private void OnValidate()
        {
            ValidationUtility.ValidateSerializedFields(this);
        }
    }
}