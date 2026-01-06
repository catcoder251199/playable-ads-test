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
        [SerializeField, ReadOnly] protected TilePage pageTarget;
        [SerializeField] protected RectTransform rectTransform;
        [SerializeField] protected RectTransform visualRectTransform;
        [SerializeField] protected float minWidth;
        [SerializeField] protected float maxWidth;
        public RectTransform RectTransform => rectTransform;

        public virtual void UpdateUIWithData(NoteData noteDataArg)
        {
            noteData = noteDataArg;
        }

        private float YToWall()
        {
            var pageY = pageTarget.RectTransform.anchoredPosition.y;
            return rectTransform.anchoredPosition.y + pageY;
        }

        public static int hitId = -1;
        private bool isHit = false;
        
        private void Update()
        {
            if (!gameObject.activeSelf || noteData.duration == 0)
                return;

            var yToWall = YToWall();
            if (yToWall <= 0 && !isHit)
            {
                isHit = true;
                Debug.Log($"Hit the wall {noteData.id}");
            }
        }

        public void SetLaneTarget(Lane target)
        {
            // if (laneTarget)
            //     laneTarget.OnLaneWidthChangedEventChannel.OnEventRaised -= OnLaneWidthChangedEventHandler;
            //
            // laneTarget = target;
            //
            // if (laneTarget)
            // {
            //     laneTarget.OnLaneWidthChangedEventChannel.OnEventRaised += OnLaneWidthChangedEventHandler;
            //     SetWidth(laneTarget.RectTransform.rect.width);
            //     SetPositionX(laneTarget.RectTransform.anchoredPosition.x);
            // }
        }

        public void SetPageTarget(TilePage target)
        {
            if (pageTarget)
                pageTarget.OnPageWidthChangedEventChannel.OnEventRaised -= OnLaneWidthChangedEventHandler;
            
            pageTarget = target;
            
            if (pageTarget)
            {
                pageTarget.OnPageWidthChangedEventChannel.OnEventRaised += OnLaneWidthChangedEventHandler;
                //SetWidth(pageTarget.RectTransform.rect.width);
                //SetPositionX(pageTarget.RectTransform.anchoredPosition.x);
                RecalculateWidth();
                RecalculateX();
            }
        }

        private void RecalculateX()
        {
            int laneIndex = noteData.lane;
            var pageRectSize = pageTarget.RectTransform.rect.size;
            float pageWidth = pageRectSize.x;
            float laneWidth = pageRectSize.x / 4;

            float x_i = -pageWidth / 2 + laneWidth / 2 + laneIndex * laneWidth;
            rectTransform.anchoredPosition = new Vector2(x_i, rectTransform.anchoredPosition.y);
        }
        
        private void RecalculateWidth()
        {
            var pageRectSize = pageTarget.RectTransform.rect.size;
            float pageWidth = pageRectSize.x;
            float laneWidth = pageRectSize.x / 4;
            laneWidth = Mathf.Max(minWidth, Mathf.Min(laneWidth, maxWidth));
            visualRectTransform.SetSizeWithCurrentAnchors(
                RectTransform.Axis.Horizontal,
                laneWidth
            );
        }

        public void OnDisable()
        {
            // if (laneTarget)
            //     laneTarget.OnLaneWidthChangedEventChannel.OnEventRaised -= OnLaneWidthChangedEventHandler;
        }

        private void SetPositionX(float x)
        {
            //var rect = rectTransform.anchoredPosition;
            //rectTransform.anchoredPosition = new Vector2(x, rect.y);
        }

        private void SetLocalPositionX(float x)
        {
            Vector2 localPos;
            
        }
        
        public void SetWidth(float width)
        {
            width = Mathf.Max(minWidth, Mathf.Min(width, maxWidth));
            ;
            visualRectTransform.SetSizeWithCurrentAnchors(
                RectTransform.Axis.Horizontal,
                width
            );
        }
        
        public void SetHeight(float height)
        {
            visualRectTransform.SetSizeWithCurrentAnchors(
                RectTransform.Axis.Vertical,
                height
            );
        }
        
        protected virtual void OnLaneWidthChangedEventHandler(OnValueChangedFromToEventArgs<TilePage, float> eventArgs)
        {
            if (pageTarget == null)
                return;
            
            var broadcaster = eventArgs.BroadCaster;
            if (broadcaster != pageTarget)
                return;
            
            //SetWidth(eventArgs.To); // Change tile width
            //var x = broadcaster.RectTransform.anchoredPosition.x;
            //SetPositionX(broadcaster.RectTransform.anchoredPosition.x); // Change tile x
            
            if (pageTarget == eventArgs.BroadCaster)
            {
                RecalculateWidth();
                RecalculateX();
            }
        }

        public override void OnDespawn()
        {
            base.OnDespawn();
            isHit = false;
        }
    }
}