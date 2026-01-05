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
        [SerializeField] private Tile tilePrefab;
        [SerializeField] private int preloadInPool = 10;
        private Queue<TilePage> pageQueue = new Queue<TilePage>();
        private GenericGameObjectPool<Tile> tilePool;
        private int _currentIndex = 0;
        
        private void Awake()
        {
            _currentIndex = 0;
            tilePool = new GenericGameObjectPool<Tile>(tilePrefab, preloadInPool, poolParent);
        }

        private void ResetBackToInitial()
        {
            _currentIndex = 0;
        }

        private void OnEnable()
        {
            onTilePageRecycledEventChannel.OnEventRaised += OnPageRecycleEventHandler;
        }

        private void OnDisable()
        {
            onTilePageRecycledEventChannel.OnEventRaised -= OnPageRecycleEventHandler;

        }

        private void OnPageRecycleEventHandler(OnTilePageRecycledEventArgs eventArgs)
        {
            if (pageQueue.Peek() != eventArgs.TilePage)
            {
                Debug.LogError("Why recycled page is different from peek of queue");
                return;
            }

            var front = pageQueue.Dequeue();
            foreach (var tile in front.TileStack)
            {
                tilePool.Despawn(tile);
            }
            front.Clear();
            
            var levelData = levelDataSO.LevelData;
            while (_currentIndex < levelData.Count)
            {
                
            }
        }
    }
}