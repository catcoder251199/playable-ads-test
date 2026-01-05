using UnityEngine;
using System;
using EventBus.Events;

namespace DefaultNamespace.Game
{
    public enum ScreenLayout
    {
        Portrait,
        Landscape
    }

    public class ScreenLayoutWatcher : MonoBehaviour
    {
        [SerializeField] private OnLayoutChangedEventChannel onLayoutChangedEventChannel;
        [SerializeField] private OnScreenSizeChangedEventChannel onScreenSizeChangedEventChannel;
        [SerializeField] private bool invokeOnStart = true;

        private int lastWidth;
        private int lastHeight;
        private ScreenLayout currentLayout;

        void Start()
        {
            lastWidth = Screen.width;
            lastHeight = Screen.height;

            currentLayout = GetLayout();

            if (invokeOnStart)
                onLayoutChangedEventChannel?.RaiseEvent(new OnLayoutChangedEventArgs(currentLayout, currentLayout));
        }

        void Update()
        {
            if (Screen.width == lastWidth && Screen.height == lastHeight)
                return;

            Debug.Log($"onScreenSizeChangedEventChannel screen size changed: ({lastWidth}, {lastHeight}) -> ({Screen.width}, {Screen.height})");
            onScreenSizeChangedEventChannel?.RaiseEvent(new OnScreenSizeChangedEventArgs(
                new Vector2(lastWidth, lastHeight), new Vector2(Screen.width, Screen.height)));
            
            lastWidth = Screen.width;
            lastHeight = Screen.height;

            var newLayout = GetLayout();
            if (newLayout != currentLayout)
            {
            Debug.Log($"onScreenSizeChangedEventChannel screen size changed: ({currentLayout}) -> ({newLayout})");
                
                onLayoutChangedEventChannel?.RaiseEvent(new OnLayoutChangedEventArgs(currentLayout, newLayout));
                currentLayout = newLayout;
            }
        }

        private ScreenLayout GetLayout()
        {
            float screenRatio = (float)Screen.width / Screen.height;

            if (screenRatio >= 1f)
                return ScreenLayout.Landscape;
            else
                return ScreenLayout.Portrait;
        }
    }
}