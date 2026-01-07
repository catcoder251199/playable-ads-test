using DefaultNamespace.GameState;
using DefaultNamespace.GameState.State;
using UnityEngine;

namespace DefaultNamespace.Game
{
    public class Boot : MonoBehaviour
    {
        [SerializeField] private GameplayController gameStateMachine;
        
        private void Awake()
        {
            Init();
        }

        private void Start()
        {
            gameStateMachine.ChangeState(gameStateMachine.InitState);
        }

        private void Init()
        {
            
        }
    }
}