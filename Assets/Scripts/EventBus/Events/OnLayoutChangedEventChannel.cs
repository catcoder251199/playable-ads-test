using DefaultNamespace.Game;
using UnityEngine;

namespace EventBus.Events
{
    public class OnLayoutChangedEventArgs : IEvent
    {
        public ScreenLayout From { get; }
        public ScreenLayout To { get; }

        public OnLayoutChangedEventArgs(ScreenLayout from, ScreenLayout to)
        {
            From = from;
            To = to;
        }
    }
    
    [CreateAssetMenu(fileName = "new OnLayoutChangedEventChannel", menuName = "EvenChannels/ OnLayoutChangedEventChannel")]
    public class OnLayoutChangedEventChannel : GenericEventChannelSO<IEvent>
    {}
}