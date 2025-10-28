using UnityEngine;
using Zenject;

namespace PopupSystem
{
    public class PopupInstaller : MonoInstaller
    {
        public const string PopupCanvasId = "PopupCanvasId";
        
        [SerializeField] private PopupConfig config;
        [SerializeField] private Canvas popupCanvas;
        
        public override void InstallBindings()
        {
            Container.Bind<PopupConfig>().FromInstance(config).AsSingle();
            
            Container.Bind<Canvas>().WithId(PopupCanvasId).FromComponentInNewPrefab(popupCanvas).UnderTransform(transform).AsSingle();
            
            Container.BindInterfacesAndSelfTo<PopupManager>().FromNew().AsSingle().NonLazy();

            Container.DeclareSignal<OnRequestPopupShowSignal>();
        }

        private void OnValidate()
        {
            if (config == null)
            {
                Debug.LogWarning("PopupConfig is not assigned in PopupInstaller!");
            }
        }
    }
    
    public struct OnRequestPopupShowSignal
    {
        public readonly string PopupId;

        public OnRequestPopupShowSignal(string popupId)
        {
            PopupId = popupId;
        }
    }
}