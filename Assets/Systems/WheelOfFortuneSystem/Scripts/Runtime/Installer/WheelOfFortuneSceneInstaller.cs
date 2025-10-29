using CoreSystem;
using UnityEngine;
using Zenject;

namespace WheelOfFortuneSystem
{
    public class WheelOfFortuneSceneInstaller : MonoInstaller
    {
        [Header("Project References")]
        [SerializeField, ValidateNotNull] private ZoneAreaConfig zoneAreaConfig;
        [SerializeField, ValidateNotNull] private WheelItemConfig wheelItemConfig;
        [SerializeField, ValidateNotNull] private WheelOfFortuneConfig wheelOfFortuneConfig;
        [Space]
        [SerializeField, ValidateNotNull] private WheelOfFortune wheelOfFortunePrefab;
        [SerializeField, ValidateNotNull] private WheelItem wheelItemPrefab;
        [SerializeField, ValidateNotNull] private ZoneArea zoneAreaPrefab;
        [SerializeField, ValidateNotNull] private ZoneItem zoneItemPrefab;
        [Space, Header("Scene References")]
        [SerializeField, ValidateNotNull] private Transform canvasTransform;
        
        public override void InstallBindings()
        {
            Container.Bind<WheelOfFortuneConfig>().FromInstance(wheelOfFortuneConfig).AsSingle();
            Container.Bind<WheelItemConfig>().FromInstance(wheelItemConfig).AsSingle();
            Container.Bind<ZoneAreaConfig>().FromInstance(zoneAreaConfig).AsSingle();
            
            Container.BindInterfacesAndSelfTo<WheelOfFortuneManager>().FromNew().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<WheelItemManager>().FromNew().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ZoneAreaManager>().FromNew().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ZoneItemManager>().FromNew().AsSingle().NonLazy();
            
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
            Container.BindFactory<ZoneItem, ZoneItem.Factory>()
                .FromComponentInNewPrefab(zoneItemPrefab)
                .UnderTransform(canvasTransform)
                .AsSingle();
            
            Container.DeclareSignal<OnCreateWheelItemsSignal>();
            Container.DeclareSignal<OnSpinStartedSignal>();
            Container.DeclareSignal<OnCreateZoneItemsSignal>();
            Container.DeclareSignal<RequestNextZoneSignal>();
            Container.DeclareSignal<RequestNextWheelSpinSignal>();
        }
        
        private void OnValidate()
        {
            ValidationUtility.ValidateSerializedFields(this);
        }
    }
    
    public struct OnCreateWheelItemsSignal
    {
        public readonly int Count;
        public readonly Transform Parent;
        public readonly int Multiplier;
        public readonly WheelOfFortuneBaseType BaseType;
            
        public OnCreateWheelItemsSignal(int count, Transform parent, int multiplier, WheelOfFortuneBaseType baseType)
        {
            Count = count;
            Parent = parent;
            Multiplier = multiplier;
            BaseType = baseType;
        }
    }
    
    public struct OnCreateZoneItemsSignal
    {
        public readonly RectTransform Parent;
            
        public OnCreateZoneItemsSignal(RectTransform parent)
        {
            Parent = parent;
        }
    }

    public struct OnSpinStartedSignal { }
    
    public struct RequestNextZoneSignal { }

    public struct RequestNextWheelSpinSignal
    {
        public readonly NextZoneData NextZoneData;
        
        public RequestNextWheelSpinSignal(NextZoneData nextZoneData)
        {
            NextZoneData = nextZoneData;
        }
    }
}