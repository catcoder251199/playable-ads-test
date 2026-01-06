using EventBus;
using EventBus.Events;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace.Game
{
    public class Lane : MonoBehaviour
    {
        [SerializeField] private OnWidthValueChangedEventChannel<Lane> onLaneWidthChangedEventChannel;
        [SerializeField] private RectTransform rectTransform;
        [SerializeField, ReadOnly] private float lastLaneWidth;

        public OnWidthValueChangedEventChannel<Lane> OnLaneWidthChangedEventChannel => onLaneWidthChangedEventChannel;
        public RectTransform RectTransform => rectTransform;
        
#if UNITY_EDITOR
        [ContextMenu("Raise LaneWidthChanged Event")]
        private void RaiseLaneWidthChangedEventInEditor()
        {
            var rectSize = rectTransform.rect.size;
            lastLaneWidth = rectSize.x;
            OnLaneWidthChangedEventChannel.OnEventRaised?.Invoke(new OnValueChangedFromToEventArgs<Lane, float>(this, lastLaneWidth, rectSize.x));
        }
#endif
        
        private void Awake()
        {
            lastLaneWidth = rectTransform.rect.size.x;
        }

        private void Update()
        {
            var rectSize = rectTransform.rect.size;
            if (!Mathf.Approximately(rectSize.x, lastLaneWidth))
            {
                lastLaneWidth = rectSize.x;
                OnLaneWidthChangedEventChannel.OnEventRaised?.Invoke(new OnValueChangedFromToEventArgs<Lane, float>(this, lastLaneWidth, rectSize.x));
            }
        }
    }
}