using UnityEngine;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class WheelOfFortuneSceneInstaller : MonoInstaller
    {
        [Header("Project References")]
        [SerializeField] private WheelOfFortune wheelOfFortunePrefab;
        [SerializeField] private WheelItem wheelItemPrefab;
        [Space, Header("Scene References")]
        [SerializeField] private Transform canvasTransform;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<WheelOfFortuneManager>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<WheelItemManager>().AsSingle().NonLazy();
            
            Container.BindFactory<WheelOfFortune, WheelOfFortune.Factory>()
                .FromComponentInNewPrefab(wheelOfFortunePrefab)
                .UnderTransform(canvasTransform)
                .AsSingle();
            Container.BindFactory<WheelItem, WheelItem.Factory>()
                .FromComponentInNewPrefab(wheelItemPrefab)
                .UnderTransform(canvasTransform)
                .AsSingle();
            
            Container.DeclareSignal<OnCreateItemsSignal>();
            Container.DeclareSignal<OnSpinStartedSignal>();
            Container.DeclareSignal<OnSpinDeadSignal>();
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
        public readonly int Multiplier;
        public readonly WheelOfFortuneBaseType BaseType;
            
        public OnCreateItemsSignal(int count, Transform parent, int multiplier, WheelOfFortuneBaseType baseType)
        {
            Count = count;
            Parent = parent;
            Multiplier = multiplier;
            BaseType = baseType;
        }
    }

    public struct OnSpinStartedSignal { }
    
    public struct OnSpinDeadSignal { }
}