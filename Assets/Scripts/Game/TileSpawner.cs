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
        [SerializeField] private OnTilePageRecycledEventChannel onTilePageRecycledEventChannel;
        [SerializeField] private TilePage[] pages;
        [SerializeField] private RectTransform poolParent;
        [SerializeField] private Tile tapTilePrefab;
        [SerializeField] private Tile holdTilePrefab;
        [SerializeField] private Tile startTilePrefab;
        
        [SerializeField] private int preloadInPool = 10;
        [SerializeField] private Lane[] lanes;
        private Queue<TilePage> pageQueue = new Queue<TilePage>();
        private GenericGameObjectPool<Tile> tapTilePool;
        private GenericGameObjectPool<Tile> holdTilePool;
        private GenericGameObjectPool<Tile> startTilePool;
        
        private int _currentIndex = 0;
        private Tile cachedStartTile;
        
        private void Awake()
        {
            _currentIndex = 0;
            tapTilePool = new GenericGameObjectPool<Tile>(tapTilePrefab, preloadInPool, poolParent);
            holdTilePool = new GenericGameObjectPool<Tile>(holdTilePrefab, preloadInPool, poolParent);
            startTilePool = new GenericGameObjectPool<Tile>(startTilePrefab, preloadInPool, poolParent);
            
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
            if (noteData.id == 0)
            {
                 return startTilePool.Spawn();
            }
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

        private void MoveTileToPool(Tile tile)
        {
            
        }

        private void SpawnTiles()
        {
            var noteList = levelDataSO.LevelData.AsReadOnly();
            var pageParent = pages[0];
            var n = noteList.Count;
            n = 5;
            while (_currentIndex < n)
            {
                var noteData = noteList[_currentIndex];
                Tile tile = null;
                tile = GetTileFromPool(noteData);

                if (!tile)
                    Debug.LogError($"nameof{nameof(TileSpawner)} spawn a NULL tile!");
                else
                {
                    tile.RectTransform.SetParent(pageParent.RectTransform);
                    tile.UpdateUIWithData(noteData); // Update Visual
                    tile.SetLaneTarget(lanes[noteData.lane]);
                    var distanceYFromHitLine = levelDataSO.DistanceFromHitLine(_currentIndex);
                    var tilePosition = tile.RectTransform.anchoredPosition;
                    tile.RectTransform.anchoredPosition = new Vector2(tilePosition.x, distanceYFromHitLine);

                    pageParent.AddTile(tile);
                }

                _currentIndex++;
            }
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

        private void OnPageRecycleEventHandler(OnTilePageRecycledEventArgs eventArgs)
        {
            return;
            if (pageQueue.Peek() != eventArgs.TilePage)
            {
                Debug.LogError("Why recycled page is different from peek of queue");
                return;
            }

            var front = pageQueue.Dequeue();
            foreach (var tile in front.TileStack)
            {
                tapTilePool.Despawn(tile);
            }
            front.Clear();
            
            var levelData = levelDataSO.LevelData;
            while (_currentIndex < levelData.Count)
            {
                
            }
        }
    }
}