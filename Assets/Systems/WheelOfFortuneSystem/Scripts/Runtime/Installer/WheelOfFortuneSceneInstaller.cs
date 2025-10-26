using UnityEngine;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class WheelOfFortuneSceneInstaller : MonoInstaller
    {
        [SerializeField] private WheelItem wheelItemPrefab;
        [SerializeField] private Transform canvasTransform;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<WheelItemManager>().AsSingle().NonLazy();
            
            Container.BindFactory<WheelItem, WheelItem.Factory>()
                .FromComponentInNewPrefab(wheelItemPrefab)
                .UnderTransform(canvasTransform)
                .AsSingle();
            
            Container.DeclareSignal<OnCreateItemsSignal>();
        }
        
        private void OnValidate()
        {
            if (wheelItemPrefab == null)
            {
                Debug.LogWarning("Wheel Item Prefab is not assigned in the WheelOfFortuneSceneInstaller.");
            }

            if (canvasTransform == null)
            {
                Debug.LogWarning("Canvas Transform is not assigned in the WheelOfFortuneSceneInstaller.");
            }
        }
    }
    
    public struct OnCreateItemsSignal
    {
        public readonly int Count;
        public readonly Transform Parent;
            
        public OnCreateItemsSignal(int count, Transform parent)
        {
            Count = count;
            Parent = parent;
        }
    }
}