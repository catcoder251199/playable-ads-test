namespace DefaultNamespace.GameState
{
    public class GameStateMachine
    {
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