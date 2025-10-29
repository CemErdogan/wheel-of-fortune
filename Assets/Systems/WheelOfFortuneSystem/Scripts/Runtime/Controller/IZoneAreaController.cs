using UnityEngine;

namespace WheelOfFortuneSystem
{
    public interface IZoneAreaController
    {
        IZoneAreaModel Model { get; }
        IZoneAreaView View { get; }
        
        void Init();
        void SetZoneIndex(int currentZoneIndex, RectTransform target);
    }
}