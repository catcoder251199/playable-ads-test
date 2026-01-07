using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Pooling;
using EventBus.Events;
using UnityEngine;

namespace DefaultNamespace.Game
{
    public class TileSpawner : MonoBehaviour
    {
        [SerializeField] private LevelDataSO levelDataSO;
        [SerializeField] private Camera uiCamera;
        [SerializeField] private OnTilePageRecycledEventChannel onTilePageRecycledEventChannel;
        [SerializeField] private TilePage[] pages;
        [SerializeField] private RectTransform poolParent;
        [SerializeField] private RectTransform hitLineRectTransform;
        [SerializeField] private Tile tapTilePrefab;
        [SerializeField] private int preloadHold = 3;
        [SerializeField] private int preloadTap = 10;
        [SerializeField] private Tile holdTilePrefab;
        [SerializeField] private Tile startTilePrefab;
        [SerializeField] private int totalLanes = 4;
        [SerializeField] private Lane[] lanes;
        private Queue<TilePage> pageQueue = new Queue<TilePage>();
        private GenericGameObjectPool<Tile> tapTilePool;
        private GenericGameObjectPool<Tile> holdTilePool;
        private GenericGameObjectPool<Tile> startTilePool;
        
        private int _currentIndex = 0;
        private int _recycleCount = 0;
        private Tile cachedStartTile;
        
        private void Awake()
        {
            _currentIndex = 0;
            _recycleCount = 0;
            tapTilePool = new GenericGameObjectPool<Tile>(tapTilePrefab, preloadTap, poolParent);
            holdTilePool = new GenericGameObjectPool<Tile>(holdTilePrefab, preloadHold, poolParent);
            startTilePool = new GenericGameObjectPool<Tile>(startTilePrefab, 1, poolParent);
            pageQueue = new Queue<TilePage>(3);
            foreach (var page in pages)
                pageQueue.Enqueue(page);
        }

        private void Start()
        {
            SpawnTiles();
        }

        private Tile GetStartTile()
        {
            if (!cachedStartTile)
            {
                cachedStartTile = Instantiate(startTilePrefab);
            }

            return cachedStartTile;
        }

        private Tile GetTileFromPool(NoteData noteData)
        {
            if (noteData.duration <= levelDataSO.TapDurationThreshold) // tap tile
            {
                 return tapTilePool.Spawn();
            }
            else // hold tile
            {
                return holdTilePool.Spawn();
            }

            return null;
        }
        
        private Tile GetStartTileFromPool()
        {
            return startTilePool.Spawn();
        }

        private float GetYHitLine() => hitLineRectTransform.anchoredPosition.y;
        
        private void SpawnTiles()
        {
            var noteList = levelDataSO.LevelData.AsReadOnly();
            var n = noteList.Count;
            var currentPageIndex = 0;
            while (_currentIndex < n && currentPageIndex < pages.Length)
            {
                var pageParent = pages[currentPageIndex];
                // Calculate y position
                var yPosition = _currentIndex == 0 ? 0 : levelDataSO.DistanceFromHitLine(_currentIndex);
                var isTileInPage = IsTilePositionYInPage(yPosition, currentPageIndex);
                if (!isTileInPage)
                {
                    currentPageIndex++;
                    continue;
                }
                
                var noteData = noteList[_currentIndex];
                Tile tile = _currentIndex == 0 ? GetStartTile() : GetTileFromPool(noteData);

                if (!tile)
                    Debug.LogError($"nameof{nameof(TileSpawner)} spawn a NULL tile!");
                else
                {
                    AttachToTileParent(tile.RectTransform, pageParent.RectTransform);
                    
                    tile.UpdateUIWithData(noteData); // Update Visual
                    tile.SetPageTarget(pageParent);
                    
                    // Update position y
                    var yPositionInPage = GetTilePositionYInPage(yPosition, currentPageIndex);
                    tile.RectTransform.anchoredPosition =
                        new Vector2(tile.RectTransform.anchoredPosition.x, yPositionInPage);
                    
                    // Calculate tile height
                    var tileHeight = levelDataSO.TileHeight(_currentIndex);
                    tile.SetHeight(tileHeight);
                    
                    pageParent.AddTile(tile);
                }

                _currentIndex++;
            }
        }

        private bool IsTilePositionYInPage(float tilePositionY, int pageIndex)
        {
            var page = pages[pageIndex];
            var pageHeight = page.RectTransform.rect.size.y;
            var yInPage = GetTilePositionYInPage(tilePositionY, pageIndex);
            return 0 <= yInPage && yInPage <= pageHeight;
        }
        
        private float GetTilePositionYInPage(float tilePositionY, int pageIndex)
        {
            var page = pages[pageIndex];
            var pageHeight = page.RectTransform.rect.size.y;
            if (_recycleCount == 0)
            {
                return tilePositionY - pageIndex * pageHeight;
            }
            else
            {
                var pageCount = pages.Length;
                return tilePositionY - pageHeight * (pageCount + _recycleCount - 1f);
            }
        }
        
        
        private void AttachToTileParent(RectTransform child, RectTransform parent)
        {
            child.SetParent(parent, false);

            child.localScale = Vector3.one;
            child.localRotation = Quaternion.identity;
            child.anchoredPosition3D = Vector3.zero;
        }
       
        private void ResetBackToInitial()
        {
            _currentIndex = 0;
        }

        private void OnEnable()
        {
            if (onTilePageRecycledEventChannel)
                onTilePageRecycledEventChannel.OnEventRaised += OnPageRecycleEventHandler;
        }

        private void OnDisable()
        {
            if (onTilePageRecycledEventChannel)
                onTilePageRecycledEventChannel.OnEventRaised -= OnPageRecycleEventHandler;
        }

        [ContextMenu("Check size")]
        public void CheckSize()
        {
            Debug.Log(pages[0].RectTransform.rect.size.y);
        }
        
        private void OnPageRecycleEventHandler(OnTilePageRecycledEventArgs eventArgs)
        {
            if (pageQueue.Count !=0 && pageQueue.Peek() != eventArgs.TilePage)
            {
                Debug.LogError("Why recycled page is different from peek of queue");
                return;
            }

            var front = eventArgs.TilePage;
            if (pageQueue.Count != 0)
                pageQueue.Dequeue();
            
            pageQueue.Enqueue(front);
            
            foreach (var tile in front.TileStack)
                ReturnTileToPool(tile);
            front.Clear();

            _recycleCount++;
            SpawnTilesAfterRecyclePage(front.PageIndex, front);
        }

        private void ReturnTileToPool(Tile tile)
        {
            if (tile is TapTile)
                tapTilePool.Despawn(tile);
            else if (tile is HoldTile)
                holdTilePool.Despawn(tile);
            else if (tile is StartTile)
                startTilePool.Despawn(tile);
        }
        
        private void SpawnTilesAfterRecyclePage(int pageIndex, TilePage page)
        {
            var noteList = levelDataSO.LevelData.AsReadOnly();
            var pageParent = pages[pageIndex];

            while (_currentIndex < noteList.Count)
            {
                // Calculate y position
                var yPosition = _currentIndex == 0 ? 0 : levelDataSO.DistanceFromHitLine(_currentIndex);
                var isTileInPage = IsTilePositionYInPage(yPosition, pageIndex);
                if (!isTileInPage)
                {
                    break;
                }
                
                var noteData = noteList[_currentIndex];
                Tile tile = _currentIndex == 0 ? GetStartTile() : GetTileFromPool(noteData);
                if (!tile)
                    Debug.LogError($"nameof{nameof(TileSpawner)} spawn a NULL tile!");
                else
                {
                    AttachToTileParent(tile.RectTransform, pageParent.RectTransform);
                    
                    tile.UpdateUIWithData(noteData); // Update Visual
                    tile.SetPageTarget(pageParent);
                    
                    // Update position y
                    var yPositionInPage = GetTilePositionYInPage(yPosition, pageIndex);
                    tile.RectTransform.anchoredPosition =
                        new Vector2(tile.RectTransform.anchoredPosition.x, yPositionInPage);
                    
                    // Calculate tile height
                    var tileHeight = levelDataSO.TileHeight(_currentIndex);
                    tile.SetHeight(tileHeight);
                    
                    pageParent.AddTile(tile);
                }
                
                _currentIndex++;
            }
           
        }
    }
}