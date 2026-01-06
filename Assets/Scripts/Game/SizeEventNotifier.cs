using EventBus.Events;
using UnityEngine;

namespace DefaultNamespace.Game
{
    public class SizeEventNotifier : MonoBehaviour
    {
        [SerializeField] private OnSizeWidthChangedEventChannel onWidthChangedEventChannel;
        
        [SerializeField] private RectTransform rectTransform;
        [SerializeField, ReadOnly] private float lastWidth;

        public OnWidthValueChangedEventChannel<SizeEventNotifier> OnWidthChangedEventChannel =>
            onWidthChangedEventChannel;

        public RectTransform RectTransform => rectTransform;

#if UNITY_EDITOR
        [ContextMenu("Raise LaneWidthChanged Event")]
        private void RaiseLaneWidthChangedEventInEditor()
        {
            var rectSize = rectTransform.rect.size;
            lastWidth = rectSize.x;
            onWidthChangedEventChannel?.OnEventRaised?.Invoke(
                new OnValueChangedFromToEventArgs<SizeEventNotifier, float>(this, lastWidth, rectSize.x));
        }
#endif

        private void Awake()
        {
            lastWidth = rectTransform.rect.size.x;
            Debug.Log($"Awake Size event notifier detect size changed! {lastWidth}");
            onWidthChangedEventChannel?.OnEventRaised?.Invoke(
                new OnValueChangedFromToEventArgs<SizeEventNotifier, float>(this, lastWidth, lastWidth));
        }

        private void Update()
        {
            CheckAndRaiseEvent();
        }

        private void CheckAndRaiseEvent()
        {
            var rectSize = rectTransform.rect.size;
            if (!Mathf.Approximately(rectSize.x, lastWidth))
            {
                lastWidth = rectSize.x;
                Debug.Log(onWidthChangedEventChannel == null ? "onWidthChangedEventChannel is NuLL" : "onWidthChangedEventChannel is not null");
                Debug.Log($"CheckAndRaiseEvent Size event notifier detect size changed! {lastWidth} -> {rectSize.x}");
                onWidthChangedEventChannel?.OnEventRaised?.Invoke(
                    new OnValueChangedFromToEventArgs<SizeEventNotifier, float>(this, lastWidth, rectSize.x));
            }
        }

    }
}