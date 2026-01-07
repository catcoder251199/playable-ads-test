using System;
using EventBus.Events;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.Game.Enum
{
    public class BackgroundHandler : MonoBehaviour
    {
        [SerializeField] private OnLayoutChangedEventChannel onScreenOrientationChangedEventChannel;
        [SerializeField] private Sprite backgroundVertical;
        [SerializeField] private Sprite backgroundHorizontal;
        [SerializeField] private Image backgroundImage;
        
        private void OnEnable()
        {
            onScreenOrientationChangedEventChannel.OnEventRaised += onScreenOrientationChangedEventHandler;
        }

        private void OnDisable()
        {
            onScreenOrientationChangedEventChannel.OnEventRaised -= onScreenOrientationChangedEventHandler;

        }

        private void onScreenOrientationChangedEventHandler(OnLayoutChangedEventArgs eventArgs)
        {
            if (eventArgs.To == ScreenLayout.Landscape)
            {
                backgroundImage.sprite = backgroundHorizontal;
            }
            else if (eventArgs.To == ScreenLayout.Portrait)
            {
                backgroundImage.sprite = backgroundVertical;
            }
        }
    }
}