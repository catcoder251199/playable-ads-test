using System;
using EventBus.Events;
using UnityEngine;

namespace DefaultNamespace.Game
{
    public class SizeAdapter : MonoBehaviour
    {
        [SerializeField] private OnWidthValueChangedEventChannel<SizeEventNotifier> onWidthChangedEventChannel;

        [SerializeField] private RectTransform retTransform;
        [SerializeField] private float minWidth = Single.MaxValue;
        [SerializeField] private float maxWidth = Single.MinValue;

        private void OnEnable()
        {
            if (onWidthChangedEventChannel)
                onWidthChangedEventChannel.OnEventRaised += OnWidthChangedEventHandler;
        }
        
        private void OnDisable()
        {
            if (onWidthChangedEventChannel)
                onWidthChangedEventChannel.OnEventRaised -= OnWidthChangedEventHandler;
        }

        private void OnWidthChangedEventHandler(OnValueChangedFromToEventArgs<SizeEventNotifier, float> eventArgs)
        {
            SetWidth(eventArgs.To);
        }

        public void SetWidth(float width)
        {
            width = Mathf.Max(minWidth, Mathf.Min(width, maxWidth));
            ;
            retTransform.SetSizeWithCurrentAnchors(
                RectTransform.Axis.Horizontal,
                width
            );
        }
    }
}