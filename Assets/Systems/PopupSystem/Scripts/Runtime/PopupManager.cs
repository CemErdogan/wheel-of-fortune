using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace PopupSystem
{
    public class PopupManager : IInitializable, IDisposable
    {
        [Inject] private readonly PopupConfig _popupConfig;
        [Inject] private readonly SignalBus _signalBus;
        [Inject] private readonly DiContainer _diContainer;
        [Inject(Id = PopupInstaller.PopupCanvasId)] private readonly Canvas _popupCanvas;
        
        private readonly Dictionary<string, Popup> _popups = new();

        public void Initialize()
        {
            SetCallbacks(true);
        }

        public void Dispose()
        {
            SetCallbacks(false);
        }
        
        private void SetCallbacks(bool value)
        {
            if (value)
            {
                _signalBus.Subscribe<OnRequestPopupShowSignal>(RequestPopupShow);
            }
            else
            {
                _signalBus.Unsubscribe<OnRequestPopupShowSignal>(RequestPopupShow);
            }
        }
        
        private void RequestPopupShow(OnRequestPopupShowSignal signal)
        {
            if (_popups.TryGetValue(signal.PopupId, out var popup))
            {
                popup.Appear();
                return;
            }

            var popupPrefab = _popupConfig.Get(signal.PopupId);
            var popupInstance = _diContainer.InstantiatePrefabForComponent<Popup>(popupPrefab, _popupCanvas.transform);
            _popups.Add(signal.PopupId, popupInstance);
            popupInstance.Appear();
        }
    }
}