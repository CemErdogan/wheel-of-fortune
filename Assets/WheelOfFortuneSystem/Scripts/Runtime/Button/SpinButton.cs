using System;
using UnityEngine;
using UnityEngine.UI;

namespace WheelOfFortuneSystem
{
    [RequireComponent(typeof(Button))]
    public class SpinButton : MonoBehaviour, ISpinButton
    {
       [SerializeField] private Button button;
       
        public event Action OnButtonClick = delegate { };

       private void OnEnable()
       {
           button.onClick.AddListener(ButtonClickCallback);
       }

       private void OnDisable()
       {
           button.onClick.RemoveListener(ButtonClickCallback);
       }

       private void ButtonClickCallback()
       {
           OnButtonClick?.Invoke();
       }

       private void OnValidate()
        {
            if (button == null)
            {
                button = GetComponent<Button>();
            }
        }
    }
}