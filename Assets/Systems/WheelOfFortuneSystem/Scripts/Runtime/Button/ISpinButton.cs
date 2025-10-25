using System;

namespace WheelOfFortuneSystem
{
    public interface ISpinButton
    {
        event Action OnButtonClick;
        bool IsClicked { get; }

        void SetInteractable(bool interactable);
    }
}