using DefaultNamespace.Game.Enum;
using UnityEngine;

namespace EventBus.Events
{
    public class OnUserLoseEventArgs : IEvent
    {
        public LoseReason Reason { get; }

        public OnUserLoseEventArgs(LoseReason reason)
        {
            Reason = reason;
        }
    }
    
    [CreateAssetMenu(fileName = "new OnUserLoseEventChannel",
        menuName = "EvenChannels/ OnUserLoseEventChannel")]
    public class OnUserLoseEventChannel : GenericEventChannelSO<OnUserLoseEventArgs>
    {
        
    }
}