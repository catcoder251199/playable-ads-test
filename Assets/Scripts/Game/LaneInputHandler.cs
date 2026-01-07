using EventBus.Events;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DefaultNamespace.Game
{
    public class LaneInputHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private OnLaneTouchUpEventChannel onLaneTouchUpEventChannel;
        [SerializeField] private OnLaneTouchDownEventChannel onLaneTouchDownEventChannel;
        [SerializeField] private int laneIndex;

        private int activePointerId = -1;

        public void OnPointerDown(PointerEventData eventData)
        {
            if (activePointerId != -1)
                return;

            activePointerId = eventData.pointerId;
            onLaneTouchDownEventChannel?.OnEventRaised?.Invoke(new OnLaneTouchDownEventArgs(laneIndex));
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (eventData.pointerId != activePointerId)
                return;
            
            onLaneTouchUpEventChannel?.OnEventRaised?.Invoke(new OnLaneTouchUpEventArgs(laneIndex));
            activePointerId = -1;
        }
    }
}