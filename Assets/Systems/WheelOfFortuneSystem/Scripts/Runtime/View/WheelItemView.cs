using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WheelOfFortuneSystem
{
    public class WheelItemView : MonoBehaviour, IWheelItemView
    {
        [SerializeField] private Image iconImage;
        [SerializeField] private TextMeshProUGUI amountText;
        
        public void Prepare(int amount, Sprite icon)
        {
            amountText.SetText(amount.ToString());
            iconImage.sprite = icon;
        }

        private void OnValidate()
        {
            if (iconImage == null)
            {
                Debug.LogWarning("Icon Image is not assigned in the WheelItemView.");
            }

            if (amountText == null)
            {
                Debug.LogWarning("Amount Text is not assigned in the WheelItemView.");
            }
        }
    }
}