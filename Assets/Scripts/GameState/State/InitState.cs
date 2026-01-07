using DefaultNamespace.Game;
using EventBus.Events;
using UnityEngine;

namespace DefaultNamespace.GameState.State
{
    public class InitState : MonoBehaviour, IGameState
    {
        [SerializeField] private GameplayController gameStateMachine;
        public void Enter()
        {
            var tileSpawner = gameStateMachine.TileSpawner;
            tileSpawner.SpawnTiles();
        }

        public void Exit()
        {
        }

        public void Tick()
        {
        }

        public void OnUserTouchLaneDownEventHandler(OnLaneTouchDownEventArgs eventArgs)
        {
            gameStateMachine.OnUserTouchLaneDownOnInit(eventArgs);
        }

        public void OnUserTouchLaneUpEventHandler(OnLaneTouchUpEventArgs eventArgs)
        {
        }
    }
}