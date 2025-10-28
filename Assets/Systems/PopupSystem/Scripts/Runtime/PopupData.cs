using UnityEngine;

namespace PopupSystem
{
    [System.Serializable]
    public struct PopupData
    {
        [field:SerializeField] public string Id { get; private set; }
        [field:SerializeField] public Popup PopupPrefab { get; private set; }
    }
}