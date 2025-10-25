using System;
using DG.Tweening;
using UnityEngine;

namespace WheelOfFortuneSystem
{
    public interface IWheelOfFortuneView
    {
        void PlaySpinAnimation(Vector3 targetRot, float duration, Ease ease, Action onComplete = null);
    }
}