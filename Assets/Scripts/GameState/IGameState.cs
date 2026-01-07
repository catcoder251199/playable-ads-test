using EventBus.Events;

namespace DefaultNamespace.GameState
{
    public interface IGameState
    {
        void Enter();
        void Exit();
        void Tick();
        void OnUserTouchLaneDownEventHandler(OnLaneTouchDownEventArgs eventArgs);
        void OnUserTouchLaneUpEventHandler(OnLaneTouchUpEventArgs eventArgs);
    }
}