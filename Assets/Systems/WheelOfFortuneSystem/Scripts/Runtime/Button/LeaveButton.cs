using CoreSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class LeaveButton : MonoBehaviour
    {
        [SerializeField, ValidateNotNull] private Button button;
        
        private void OnEnable()
        {
            button.onClick.AddListener(ClickCallback);
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(ClickCallback);
        }
        
        public void SetInteractable(bool interactable)
        {
            button.interactable = interactable;
        }
        
        private void ClickCallback()
        {
            button.interactable = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
        private void OnValidate()
        {
            if (button == null)
            {
                button = GetComponentInChildren<Button>();
            }
            ValidationUtility.ValidateSerializedFields(this);
        }
        
        public class Factory : PlaceholderFactory<LeaveButton> { }
    }
}