using System.Collections;
using DefaultNamespace.Game;
using EventBus.Events;
using UnityEngine;

namespace DefaultNamespace.GameState.State
{
    public class PlayState : MonoBehaviour, IGameState
    {
        [SerializeField] private string BGMSongName = "RoundAndRound";
        [SerializeField] private GameplayController gameStateMachine;
        public void Enter()
        {
            gameStateMachine.PageMover.SetMoveable(true);
            gameStateMachine.AudioManager.PlayBGM(BGMSongName);
            gameStateMachine.SongUIRectTransform.gameObject.SetActive(false);
            gameStateMachine.ProgressBarHandler.gameObject.SetActive(true);
        }

        public void Exit()
        {
        }

        public void Tick()
        {
        }

        public void OnUserTouchLaneDownEventHandler(OnLaneTouchDownEventArgs eventArgs)
        {
            gameStateMachine.OnUserTouchLaneDownEventHandlerOnPlay(eventArgs);
        }

        public void OnUserTouchLaneUpEventHandler(OnLaneTouchUpEventArgs eventArgs)
        {
            gameStateMachine.OnUserTouchLaneUpEventHandlerOnPlay(eventArgs);
        }
    }
}