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
        [SerializeField] private BorderHandler2 borderHandler2;
        public void Enter()
        {
            borderHandler2.StopBlink();
            StartCoroutine(WaitAndShowEC());
        }

        IEnumerator WaitAndShowEC()
        {
            yield return new WaitForSeconds(ecWaitTime);
            gameStateMachine.ECPopup.Open();
        }

        public void OnCTAClicked()
        {
            Debug.Log("CTA Clicked!");
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