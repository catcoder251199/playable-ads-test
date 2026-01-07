using System;
using System.Collections.Generic;
using EventBus.Events;
using UnityEngine;

namespace DefaultNamespace.Game
{
    public class GameplayController : MonoBehaviour
    {
        [SerializeField] private LevelDataSO levelData;
        [SerializeField] private OnLaneTouchUpEventChannel onLaneTouchUpEventChannel;
        [SerializeField] private OnLaneTouchDownEventChannel onLaneTouchDownEventChannel;
        [SerializeField] private OnTileTouchDownEventChannel onTileTouchDownEventChannel;
        [SerializeField] private OnTileTouchUpEventChannel onTileTouchUpEventChannel;
        private int _currentTileIndex; // use to check targeted tile of user
        private HashSet<int> tappedSet; // set of tile ids

        private Queue<int>[] idLanes;
        private Queue<int>[] tappedQueues;
        private bool gameStarted = false;
        private void Awake()
        {
            var laneCount = levelData.LaneCount;
            idLanes = new Queue<int>[laneCount];
            tappedQueues = new Queue<int>[laneCount];
            for (int i = 0; i < laneCount; i++)
            {
                idLanes[i] = new Queue<int>();
                tappedQueues[i] = new Queue<int>();
            }
            
            foreach (var noteData in levelData.LevelData)
            {
                idLanes[noteData.lane].Enqueue(noteData.id);
            }
        }

        private void OnEnable()
        {
            onLaneTouchUpEventChannel.OnEventRaised += OnUserTouchLaneUpEventHandler;
            onLaneTouchDownEventChannel.OnEventRaised += OnUserTouchLaneDownEventHandler;
        }
        
        private void OnDisable()
        {
            onLaneTouchUpEventChannel.OnEventRaised -= OnUserTouchLaneUpEventHandler;
            onLaneTouchDownEventChannel.OnEventRaised -= OnUserTouchLaneDownEventHandler;
        }

        private void OnUserTouchLaneDownEventHandler(OnLaneTouchDownEventArgs eventArgs)
        {
            int laneIndex = eventArgs.LaneIndex;
            var tappedId = idLanes[laneIndex].Peek();
            
            if (!gameStarted && tappedId != 0)
            {
                Debug.LogError("please touch start tile to start!");
                return;
            }
            
            if (idLanes[laneIndex].Count == 0)
            {
                Debug.Log($"Lane {laneIndex} is finished!");
                return;
            }

            var noteList = levelData.LevelData;

            if (tappedId == 0)
            {
                tappedQueues[laneIndex].Enqueue(idLanes[laneIndex].Dequeue());
                Debug.Log($"Touch down start Tile on lane {laneIndex}");
                gameStarted = true;
                return;
            }
            
            bool tapWrong = false;
            for(int i = 0; i < idLanes.Length; i++)
            {
                if (laneIndex != i && idLanes[i].Count != 0)
                {
                    var tappedNoteData = noteList[tappedId];
                    var otherNoteData = noteList[idLanes[i].Peek()];
                    
                    if (otherNoteData.time + 0.0001 < tappedNoteData.time)
                    {
                        // tap wrong front note
                        tapWrong = true;
                        Debug.LogError("wrong front node -> You lose!");
                        break;
                    }
                }
            }

            if (!tapWrong)
            {
                tappedQueues[laneIndex].Enqueue(idLanes[laneIndex].Dequeue());
                Debug.Log($"Touched down {tappedId}");
                // tap good
                onTileTouchDownEventChannel.OnEventRaised?.Invoke(new OnTileTouchDownEventArgs(tappedId));
            }
        }
        
        private void OnUserTouchLaneUpEventHandler(OnLaneTouchUpEventArgs eventArgs)
        {
            int laneIndex = eventArgs.LaneIndex;
            while (tappedQueues[laneIndex].Count != 0)
            {
                var tappedId = tappedQueues[laneIndex].Dequeue();
                Debug.Log($"Touched up {tappedId}");
                onTileTouchUpEventChannel.OnEventRaised?.Invoke(new OnTileTouchUpEventArgs(tappedId));
            }
        }

        private int CountParallelsFrom(int index)
        {
            var noteList = levelData.LevelData.AsReadOnly();
            var parallelTileCount = 1;
            for (int i = _currentTileIndex + 1; i < noteList.Count; i++)
            {
                if (Mathf.Approximately(noteList[_currentTileIndex].delta, 0))
                {
                    parallelTileCount++;
                }
                break;
            }

            return parallelTileCount;
        }
        
        
        
        private void OnUserTouchLaneDownEventHandler2(int laneIndex)
        {
            var noteList = levelData.LevelData.AsReadOnly();

            while (_currentTileIndex < noteList.Count)
            {
                var noteData = noteList[_currentTileIndex];
                if (laneIndex == noteData.lane)
                {
                    if (tappedSet.Contains(noteData.id)) // reclick a tapped tile
                    {
                        // ignore
                    }
                    else
                    {
                        // tap to untapped tile
                        tappedSet.Add(laneIndex);
                        onTileTouchDownEventChannel.OnEventRaised?.Invoke(new OnTileTouchDownEventArgs(noteData.id));

                        // check if click all front tiles
                        var parallelTileCount = CountParallelsFrom(_currentTileIndex);
                        if (parallelTileCount == tappedSet.Count)
                        {
                            _currentTileIndex += parallelTileCount; // Move to next front tiles
                        }
                    }
                }
                else
                {
                    bool canMoveToNextTile = _currentTileIndex + 1 < noteList.Count &&
                                             Mathf.Approximately(noteList[_currentTileIndex + 1].delta, 0);

                    if (canMoveToNextTile)
                        _currentTileIndex++;
                    else
                    {
                        break;
                    }
                }
            }
        }
        
        private void OnUserTouchLaneUpEventHandler2(int laneIndex)
        {
            var noteList = levelData.LevelData.AsReadOnly();
            
        }
    }
}