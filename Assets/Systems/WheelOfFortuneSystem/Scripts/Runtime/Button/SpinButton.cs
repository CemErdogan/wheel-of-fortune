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
       public bool IsClicked => !button.interactable;

        private void OnEnable()
       {
           button.onClick.AddListener(ButtonClickCallback);
       }

       private void OnDisable()
       {
           button.onClick.RemoveListener(ButtonClickCallback);
       }


       public void SetInteractable(bool interactable)
       {
              button.interactable = interactable;
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