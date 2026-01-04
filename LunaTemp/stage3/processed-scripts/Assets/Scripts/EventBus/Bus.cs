namespace EventBus
{
    public interface IEvent
    {
        
    }
    public static class Bus<T> where T : IEvent
    {
        public delegate void Event(T evt);

        public static event Event onEvent;
        public static void Raise(T evt) => onEvent?.Invoke(evt);
    }
}