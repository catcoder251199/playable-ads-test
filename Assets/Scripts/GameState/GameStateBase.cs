namespace DefaultNamespace.GameState
{
    public abstract class GameStateBase /*: IGameState*/
    {
        protected GameStateMachine machine;

        protected GameStateBase(GameStateMachine machine)
        {
            this.machine = machine;
        }

        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void Tick() { }
    }
}