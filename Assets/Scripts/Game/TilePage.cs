using System.Collections.Generic;
using EventBus.Events;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace.Game
{
    public class TilePage : MonoBehaviour
    {
        [SerializeField] private OnPageWidthChangedEventChannel onPageWidthChangedEventChannel;
        [SerializeField] private OnTilePageRecycledEventChannel onTilePageRecycledEventChannel;
        [SerializeField] private float speed = 300f;
        [SerializeField] private float y;
        [SerializeField] private float yDest;
        [SerializeField] private float clampedFrameDeltaTime = 0.02f;
        
        [FormerlySerializedAs("rect")] [SerializeField] private RectTransform rectTransform;
        private float panelHeight;

        private Stack<Tile> _tileStack = new Stack<Tile>(10);

        public Stack<Tile> TileStack => _tileStack;

        public RectTransform RectTransform => rectTransform;
        public OnPageWidthChangedEventChannel OnPageWidthChangedEventChannel => onPageWidthChangedEventChannel;

        
        [SerializeField, ReadOnly] private float lastWidth;
        
        private void Awake()
        {
            if (rectTransform == null)
                rectTransform = GetComponent<RectTransform>();
            lastWidth = rectTransform.rect.size.x;
        }

        private void OnScreenChangedEventHandler()
        {
            // panel Height = new Height;
        }

        public void AddTile(Tile tile)
        {
            _tileStack.Push(tile);
        }

        void Update()
        {
            CheckWidth();
            
            if (Time.deltaTime > clampedFrameDeltaTime) // if the last frame stuck then the tiles should stop moving
                return;
            
            rectTransform.anchoredPosition += Vector2.down * (speed * Time.deltaTime);

            y = rectTransform.anchoredPosition.y;
            var rectSizeY = rectTransform.rect.size.y;
            yDest = -rectSizeY;
            
            if (rectTransform.anchoredPosition.y <= yDest)
            {
                // Back to position
                rectTransform.anchoredPosition = new Vector2(
                    rectTransform.anchoredPosition.x,
                    rectSizeY
                );
                
                // Notify Event
                onTilePageRecycledEventChannel?.RaiseEvent(new OnTilePageRecycledEventArgs(this));
            }
        }

        private void CheckWidth()
        {
            var rectSize = rectTransform.rect.size;
            if (!Mathf.Approximately(rectSize.x, lastWidth))
            {
                lastWidth = rectSize.x;
                OnPageWidthChangedEventChannel.OnEventRaised?.Invoke(new OnValueChangedFromToEventArgs<TilePage, float>(this, lastWidth, rectSize.x));
            }
        }

        public void Clear()
        {
            _tileStack.Clear();
        }

        [ContextMenu("Check Y")]
        private void CheckY()
        {
            y = rectTransform.anchoredPosition.y;
            yDest = -panelHeight - rectTransform.rect.size.y / 2f;
        }
    }
}