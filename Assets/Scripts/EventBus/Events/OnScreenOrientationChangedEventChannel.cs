using DefaultNamespace.Game;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace EventBus.Events
{
    public class OnScreenOrientationChangedEventArgs : IEvent
    {
        public ScreenLayout From { get; }
        public ScreenLayout To { get; }

        public OnScreenOrientationChangedEventArgs(ScreenLayout from, ScreenLayout to)
        {
            From = from;
            To = to;
        }
    }
    
    [CreateAssetMenu(fileName = "new OnScreenOrientationChangedEventChannel", menuName = "EvenChannels/ OnScreenOrientationChangedEventChannel")]
    public class OnScreenOrientationChangedEventChannel : GenericEventChannelSO<OnScreenOrientationChangedEventArgs>
    {}
}