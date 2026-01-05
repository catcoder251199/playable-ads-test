using DefaultNamespace.Game;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace EventBus.Events
{
    public class OnScreenSizeChangedEventArgs : IEvent
    {
        public Vector2 FromSize { get; }
        public Vector2 ToSize { get; }

        public OnScreenSizeChangedEventArgs(Vector2 from, Vector2 to)
        {
            FromSize = from;
            ToSize = to;
            
        }
    }
    
    [CreateAssetMenu(fileName = "new OnScreenSizeChangedEventChannel", menuName = "EvenChannels/ OnScreenSizeChangedEventChannel")]
    public class OnScreenSizeChangedEventChannel : GenericEventChannelSO<IEvent>
    {}
}