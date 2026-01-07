using System.Collections;
using DefaultNamespace.Game;
using EventBus.Events;
using UnityEngine;

namespace DefaultNamespace.GameState.State
{
    public class EndState : MonoBehaviour, IGameState
    {
        [SerializeField] private string BGMSongName = "RoundAndRound";
        [SerializeField] private GameplayController gameStateMachine;
        [SerializeField] private float ecWaitTime = 1f;
        public void Enter()
        {
            StartCoroutine(WaitAndShowEC());
        }

        IEnumerator WaitAndShowEC()
        {
            yield return new WaitForSeconds(ecWaitTime);
            gameStateMachine.ECPopup.Open();
        }

        private void OnCTAClicked()
        {
            Luna.Unity.Playable.InstallFullGame();
        }

        public void Exit()
        {
        }

        public void Tick()
        {
        }

        public void OnUserTouchLaneDownEventHandler(OnLaneTouchDownEventArgs eventArgs)
        {
            Debug.Log("Game is ended");
        }

        public void OnUserTouchLaneUpEventHandler(OnLaneTouchUpEventArgs eventArgs)
        {
            Debug.Log("Game is ended");
        }
    }
}