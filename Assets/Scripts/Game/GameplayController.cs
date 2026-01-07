using System.Collections.Generic;
using DefaultNamespace.GameState;
using DefaultNamespace.GameState.State;
using EventBus.Events;
using UnityEngine;

namespace DefaultNamespace.Game
{
    public class GameplayController : MonoBehaviour
    {
        [SerializeField] private InitState initState;
        [SerializeField] private PlayState playState;
        
        [SerializeField] private TileSpawner tileSpawner;
        [SerializeField] private PageMover pageMover;
        [SerializeField] private AudioManager.AudioManager audioManager;
        [SerializeField] private RectTransform songUIRectTransform;
        [SerializeField] private ProgressBarHandler progressBarHandler;
        
        [SerializeField] private LevelDataSO levelData;
        [SerializeField] private OnLaneTouchUpEventChannel onLaneTouchUpEventChannel;
        [SerializeField] private OnLaneTouchDownEventChannel onLaneTouchDownEventChannel;
        [SerializeField] private OnTileTouchDownEventChannel onTileTouchDownEventChannel;
        [SerializeField] private OnTileTouchUpEventChannel onTileTouchUpEventChannel;
        [SerializeField] private OnUserGainedScoreEventChannel onUserGainedScoreEventChannel;
        [SerializeField] private OnUserProgressChangedEventChannel onUserProgressChangedEventChannel;
        
        private int _currentTileIndex; // use to check targeted tile of user
        private HashSet<int> tappedSet; // set of tile ids

        private Queue<int>[] idLanes;
        private Queue<int>[] tappedQueues;
        private bool gameStarted = false;

        public InitState InitState => initState;
        public PlayState PlayState => playState;

        public TileSpawner TileSpawner => tileSpawner;
        public PageMover PageMover => pageMover;
        public AudioManager.AudioManager AudioManager => audioManager;
        public RectTransform SongUIRectTransform => songUIRectTransform;
        public ProgressBarHandler ProgressBarHandler => progressBarHandler;
        
        public IGameState CurrentState { get; private set; }

        private int _tappedTotal = 0;

        public void ChangeState(IGameState newState)
        {
            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }

        public void Tick()
        {
            CurrentState.Tick();
        }
        
        private void Awake()
        {
            _tappedTotal = 0;
            InitQueues();
        }

        private void InitQueues()
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
            onUserGainedScoreEventChannel.OnEventRaised += OnUserGainedScoreEventHandler;
        }
        
        private void OnDisable()
        {
            onLaneTouchUpEventChannel.OnEventRaised -= OnUserTouchLaneUpEventHandler;
            onLaneTouchDownEventChannel.OnEventRaised -= OnUserTouchLaneDownEventHandler;
            onUserGainedScoreEventChannel.OnEventRaised -= OnUserGainedScoreEventHandler;
        }

        private void OnUserGainedScoreEventHandler(OnUserGainedScoreEventArgs eventArgs)
        {
           
        }
        
        private void OnUserTouchLaneUpEventHandler(OnLaneTouchUpEventArgs eventArgs)
        {
            CurrentState.OnUserTouchLaneUpEventHandler(eventArgs);
        }
        
        private void OnUserTouchLaneDownEventHandler(OnLaneTouchDownEventArgs eventArgs)
        {
            CurrentState.OnUserTouchLaneDownEventHandler(eventArgs);
        }

        public void OnUserTouchLaneDownOnInit(OnLaneTouchDownEventArgs eventArgs)
        {
            int laneIndex = eventArgs.LaneIndex;
            var tappedId = idLanes[laneIndex].Peek();
            
            if (!gameStarted && tappedId != 0)
            {
                Debug.LogError("please touch start tile to start!");
                return;
            }
            
            if (tappedId == 0)
            {
                tappedQueues[laneIndex].Enqueue(idLanes[laneIndex].Dequeue());
                _tappedTotal += 1;
                onUserProgressChangedEventChannel.OnEventRaised?.Invoke(new OnUserProgressChangedEventArgs(_tappedTotal, levelData.LevelData.Count));
                gameStarted = true;
                ChangeState(PlayState);
            }
        }

        public void OnUserTouchLaneDownEventHandlerOnPlay(OnLaneTouchDownEventArgs eventArgs)
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
                _tappedTotal += 1;
                tappedQueues[laneIndex].Enqueue(idLanes[laneIndex].Dequeue());
                Debug.Log($"Touched down {tappedId}");
                // tap good
                onTileTouchDownEventChannel.OnEventRaised?.Invoke(new OnTileTouchDownEventArgs(tappedId));
                onUserProgressChangedEventChannel.OnEventRaised?.Invoke(new OnUserProgressChangedEventArgs(_tappedTotal, levelData.LevelData.Count));
            }
        }
        
        public void OnUserTouchLaneUpEventHandlerOnPlay(OnLaneTouchUpEventArgs eventArgs)
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
    }
}