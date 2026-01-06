using EventBus.Events;
using UnityEngine;

namespace DefaultNamespace.Game
{
    public class SizeEventNotifier : MonoBehaviour
    {
        [SerializeField] private OnWidthValueChangedEventChannel<SizeEventNotifier> onWidthChangedEventChannel;
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
            OnWidthChangedEventChannel.OnEventRaised?.Invoke(
                new OnValueChangedFromToEventArgs<SizeEventNotifier, float>(this, lastWidth, rectSize.x));
        }
#endif

        private void Awake()
        {
            lastWidth = rectTransform.rect.size.x;
        }

        private void Update()
        {
            var rectSize = rectTransform.rect.size;
            if (!Mathf.Approximately(rectSize.x, lastWidth))
            {
                lastWidth = rectSize.x;
                OnWidthChangedEventChannel.OnEventRaised?.Invoke(
                    new OnValueChangedFromToEventArgs<SizeEventNotifier, float>(this, lastWidth, rectSize.x));
            }
        }
    }
}