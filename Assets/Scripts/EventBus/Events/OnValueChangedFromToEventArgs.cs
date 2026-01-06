namespace EventBus.Events
{
    public class OnValueChangedFromToEventArgs<T1, T2> : IEvent
    {
        public T1 BroadCaster;
        public T2 From;
        public T2 To;

        public OnValueChangedFromToEventArgs(T1 broadCaster, T2 from, T2 to)
        {
            BroadCaster = broadCaster;
            From = from;
            To = to;
        }
        
        public OnValueChangedFromToEventArgs()
        {
        }
    }
}