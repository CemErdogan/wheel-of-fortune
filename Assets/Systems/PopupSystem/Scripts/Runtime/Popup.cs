using UnityEngine;

namespace PopupSystem
{
    public abstract class Popup : MonoBehaviour
    {
        public virtual void Prepare(IPopupContext context){}
        public abstract void Appear();
        public abstract void Disappear();
    }
}