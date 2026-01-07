using System;
using DefaultNamespace.Game.Enum;
using DefaultNamespace.Pooling;
using EventBus.Events;
using UnityEngine;

namespace DefaultNamespace.Game
{
    public abstract class Tile : PoolableMonoBehaviour
    {
        [SerializeField] protected LevelDataSO levelDataSo;
        
        [SerializeField] protected OnTileTouchDownEventChannel onTileTouchDownEventChannel;
        [SerializeField] protected OnTileTouchUpEventChannel onTileTouchUpEventChannel;
        
        [SerializeField] protected NoteData noteData;
        [SerializeField, ReadOnly] protected Lane laneTarget;
        [SerializeField, ReadOnly] protected TilePage pageTarget;
        [SerializeField] protected RectTransform rectTransform;
        [SerializeField] protected RectTransform visualRectTransform;
        [SerializeField] protected float minWidth;
        [SerializeField] protected float maxWidth;
        public RectTransform RectTransform => rectTransform;

        protected float yHitLine = 0;

        private void OnEnable()
        {
            onTileTouchDownEventChannel.OnEventRaised += OnTileTouchDownEventHandler;
            onTileTouchUpEventChannel.OnEventRaised += OnTileTouchUpEventHandler;
        }
        
        private void OnDisable()
        {
            onTileTouchDownEventChannel.OnEventRaised -= OnTileTouchDownEventHandler;
            onTileTouchUpEventChannel.OnEventRaised -= OnTileTouchUpEventHandler;
        }
        
        public virtual void UpdateUIWithData(NoteData noteDataArg)
        {
            noteData = noteDataArg;
        }

        public void SetYHitLine(float y) => yHitLine = y;

        protected float YToWall()
        {
            var pageY = pageTarget.RectTransform.anchoredPosition.y;
            return rectTransform.anchoredPosition.y + pageY;
        }
        
        protected RateLevel CalculateRateLevel()
        {
            var yToWall = YToWall();
            if (yToWall > yHitLine)
            {
                float d = yToWall - yHitLine;
                float minD = levelDataSo.MinDistanceYTappable;
                if (d > minD)
                {
                    return RateLevel.Good;
                }

                if (d > minD / 2f)
                {
                    return RateLevel.Great;
                }
                
                return RateLevel.Perfect;
            }

            return RateLevel.Good;
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

        public void SetPageTarget(TilePage target)
        {
            if (pageTarget)
                pageTarget.OnPageWidthChangedEventChannel.OnEventRaised -= OnLaneWidthChangedEventHandler;
            
            pageTarget = target;
            
            if (pageTarget)
            {
                pageTarget.OnPageWidthChangedEventChannel.OnEventRaised += OnLaneWidthChangedEventHandler;
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
        protected abstract void OnTileTouchDownEventHandler(OnTileTouchDownEventArgs eventArgs);
        protected abstract void OnTileTouchUpEventHandler(OnTileTouchUpEventArgs eventArgs);
    }
}