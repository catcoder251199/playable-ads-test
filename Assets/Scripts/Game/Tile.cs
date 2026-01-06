using System;
using DefaultNamespace.Pooling;
using EventBus.Events;
using UnityEngine;

namespace DefaultNamespace.Game
{
    public abstract class Tile : PoolableMonoBehaviour
    {
        [SerializeField] protected NoteData noteData;
        [SerializeField, ReadOnly] protected Lane laneTarget;
        [SerializeField] protected RectTransform rectTransform;
        [SerializeField] protected float minWidth;
        [SerializeField] protected float maxWidth;
        public RectTransform RectTransform => rectTransform;

        public virtual void UpdateUIWithData(NoteData noteDataArg)
        {
            noteData = noteDataArg;
        }

        public void SetLaneTarget(Lane target)
        {
            if (laneTarget)
                laneTarget.OnLaneWidthChangedEventChannel.OnEventRaised -= OnLaneWidthChangedEventHandler;
            
            laneTarget = target;
            
            if (laneTarget)
            {
                laneTarget.OnLaneWidthChangedEventChannel.OnEventRaised += OnLaneWidthChangedEventHandler;
                SetWidth(laneTarget.RectTransform.rect.width);
                SetPositionX(laneTarget.RectTransform.anchoredPosition.x);
            }
        }

        public void OnDisable()
        {
            if (laneTarget)
                laneTarget.OnLaneWidthChangedEventChannel.OnEventRaised -= OnLaneWidthChangedEventHandler;
        }

        private void SetPositionX(float x)
        {
            var rect = rectTransform.anchoredPosition;
            rectTransform.anchoredPosition = new Vector2(x, rect.y);
        }
        
        private void SetWidth(float width)
        {
            width = Mathf.Max(minWidth, Mathf.Min(width, maxWidth));
            ;
            rectTransform.SetSizeWithCurrentAnchors(
                RectTransform.Axis.Horizontal,
                width
            );
        }
        
        protected virtual void OnLaneWidthChangedEventHandler(OnValueChangedFromToEventArgs<Lane, float> eventArgs)
        {
            if (laneTarget == null)
                return;
            
            var broadcaster = eventArgs.BroadCaster;
            if (broadcaster != laneTarget)
                return;
            
            SetWidth(eventArgs.To); // Change tile width
            var x = broadcaster.RectTransform.anchoredPosition.x;
            SetPositionX(broadcaster.RectTransform.anchoredPosition.x); // Change tile x
        }

        public abstract void ResetUI();
    }
}