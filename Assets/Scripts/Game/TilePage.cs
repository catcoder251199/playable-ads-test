using System.Collections.Generic;
using EventBus.Events;
using UnityEngine;

namespace DefaultNamespace.Game
{
    public class TilePage : MonoBehaviour
    {
        [SerializeField] private OnTilePageRecycledEventChannel onTilePageRecycledEventChannel;
        [SerializeField] private float speed = 300f;
        [SerializeField] private float y;
        [SerializeField] private float yDest;
        
        [SerializeField] private RectTransform rect;
        private float panelHeight;

        private Stack<Tile> _tileStack = new Stack<Tile>(10);

        public Stack<Tile> TileStack => _tileStack;

        private void Awake()
        {
            if (rect == null)
                rect = GetComponent<RectTransform>();
        }

        private void OnScreenChangedEventHandler()
        {
            // panel Height = new Height;
        }

        void Update()
        {
            rect.anchoredPosition += Vector2.down * (speed * Time.deltaTime);

            y = rect.anchoredPosition.y;
            var rectSizeY = rect.rect.size.y;
            yDest = -rectSizeY;
            
            if (rect.anchoredPosition.y <= yDest)
            {
                // Back to position
                rect.anchoredPosition = new Vector2(
                    rect.anchoredPosition.x,
                    rectSizeY
                );
                
                // Notify Event
                onTilePageRecycledEventChannel?.RaiseEvent(new OnTilePageRecycledEventArgs(this));
            }
        }

        public void Clear()
        {
            _tileStack.Clear();
        }

        [ContextMenu("Check Y")]
        private void CheckY()
        {
            y = rect.anchoredPosition.y;
            yDest = -panelHeight - rect.rect.size.y / 2f;
        }
    }
}