using UnityEngine;

namespace PopupSystem
{
    public abstract class Popup : MonoBehaviour
    {
        public abstract void Appear();
        public abstract void Disappear();
    }
}