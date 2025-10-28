using CoreSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PopupSystem.Popups
{
    public class GiveUpButton : MonoBehaviour
    {
        [SerializeField, ValidateNotNull] private Popup popup;
        [SerializeField, ValidateNotNull] private Button button;

        private void OnEnable()
        {
            button.onClick.AddListener(ClickCallback);
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(ClickCallback);
        }
        
        private void ClickCallback()
        {
            button.interactable = false;
            popup.Disappear();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void OnValidate()
        {
            ValidationUtility.ValidateSerializedFields(this);
        }
    }
}