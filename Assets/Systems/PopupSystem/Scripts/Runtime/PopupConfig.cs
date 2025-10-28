using UnityEngine;

namespace PopupSystem
{
    [CreateAssetMenu(fileName = "PopupConfig", menuName = "PopupSystem/Configs/PopupConfig", order = 0)]
    public class PopupConfig : ScriptableObject
    {
        [SerializeField] private PopupData[] popups;

        public Popup Get(string id)
        {
            foreach (var popupData in popups)
            {
                if (popupData.Id == id)
                {
                    return popupData.PopupPrefab;
                }
            }

            Debug.LogError($"Popup with id {id} not found!");
            return null;
        }
    }
}