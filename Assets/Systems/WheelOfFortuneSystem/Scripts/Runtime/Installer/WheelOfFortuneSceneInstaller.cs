using UnityEngine;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class WheelOfFortuneSceneInstaller : MonoInstaller
    {
        [Header("Project References")]
        [SerializeField] private WheelOfFortune wheelOfFortunePrefab;
        [SerializeField] private WheelItem wheelItemPrefab;
        [SerializeField] private ZoneArea zoneAreaPrefab;
        [Space, Header("Scene References")]
        [SerializeField] private Transform canvasTransform;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<WheelOfFortuneManager>().FromNew().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<WheelItemManager>().FromNew().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ZoneAreaManager>().FromNew().AsSingle().NonLazy();
            
            Container.BindFactory<WheelOfFortune, WheelOfFortune.Factory>()
                .FromComponentInNewPrefab(wheelOfFortunePrefab)
                .UnderTransform(canvasTransform)
                .AsSingle();
            Container.BindFactory<WheelItem, WheelItem.Factory>()
                .FromComponentInNewPrefab(wheelItemPrefab)
                .UnderTransform(canvasTransform)
                .AsSingle();
            Container.BindFactory<ZoneArea, ZoneArea.Factory>()
                .FromComponentInNewPrefab(zoneAreaPrefab)
                .UnderTransform(canvasTransform)
                .AsSingle();
            
            Container.DeclareSignal<OnCreateItemsSignal>();
            Container.DeclareSignal<OnSpinStartedSignal>();
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

            if (wheelOfFortunePrefab == null)
            {
                Debug.LogWarning("Wheel Of Fortune Prefab is not assigned in the WheelOfFortuneSceneInstaller.");
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
}