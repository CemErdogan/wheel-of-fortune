using CoreSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WheelOfFortuneSystem
{
    public class WheelItemView : MonoBehaviour, IWheelItemView
    {
        [SerializeField, ValidateNotNull] private Image iconImage;
        [SerializeField, ValidateNotNull] private TextMeshProUGUI amountText;
        
        public void Prepare(int amount, Sprite icon)
        {
            amountText.SetText(amount.ToString());
            iconImage.sprite = icon;
        }

        private void OnValidate()
        {
            ValidationUtility.ValidateSerializedFields(this);
        }
    }
}