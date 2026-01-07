using DefaultNamespace.Game;
using DefaultNamespace.GameState.State;
using UnityEngine;

namespace DefaultNamespace.GameState
{
    public class GameStateMachine : MonoBehaviour
    {
        [SerializeField] private InitState initState;
        [SerializeField] private GameplayController gameplayController;
        [SerializeField] private TileSpawner tileSpawner;

        public InitState InitState => initState;

        public TileSpawner TileSpawner => tileSpawner;
        public GameplayController GameplayController => gameplayController;
        public IGameState CurrentState { get; private set; }

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
    }
}