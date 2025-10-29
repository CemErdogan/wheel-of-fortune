using System;
using DG.Tweening;
using UnityEngine;

namespace WheelOfFortuneSystem
{
    public interface IWheelOfFortuneView
    {
        void PlaySpinAnimation(Vector3 targetRot, float duration, Ease ease, Action onComplete = null);
        void SetBaseImage(Sprite newImage);
        void SetIndicatorImage(Sprite dataIndicatorImage);
        void SetHeaderText(string text, Color color);
        void SetInfoText(string text, Color color);
        Transform GetItemParent();
    }
}