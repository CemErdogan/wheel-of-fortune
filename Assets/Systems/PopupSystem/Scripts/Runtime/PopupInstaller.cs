using CoreSystem;
using UnityEngine;
using Zenject;

namespace PopupSystem
{
    public class PopupInstaller : MonoInstaller
    {
        public const string PopupCanvasId = "PopupCanvasId";
        
        [SerializeField, ValidateNotNull] private PopupConfig config;
        [SerializeField, ValidateNotNull] private Canvas popupCanvas;
        
        public override void InstallBindings()
        {
            Container.Bind<PopupConfig>().FromInstance(config).AsSingle();
            
            Container.Bind<Canvas>().WithId(PopupCanvasId).FromComponentInNewPrefab(popupCanvas).UnderTransform(transform).AsSingle();
            
            Container.BindInterfacesAndSelfTo<PopupManager>().FromNew().AsSingle().NonLazy();

            Container.DeclareSignal<OnRequestPopupShowSignal>();
        }

        private void OnValidate()
        {
            ValidationUtility.ValidateSerializedFields(this);
        }
    }
    
    public struct OnRequestPopupShowSignal
    {
        public readonly string PopupId;
        public readonly IPopupContext PopupContext;

        public OnRequestPopupShowSignal(string popupId, IPopupContext popupContext = null)
        {
            PopupId = popupId;
            PopupContext = popupContext;
        }
    }
}