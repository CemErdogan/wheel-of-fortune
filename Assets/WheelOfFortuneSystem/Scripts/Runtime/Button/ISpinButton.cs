using System;

namespace WheelOfFortuneSystem
{
    public interface ISpinButton
    {
        event Action OnButtonClick;
    }
}