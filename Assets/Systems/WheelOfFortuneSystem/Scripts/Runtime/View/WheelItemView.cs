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
    }
}