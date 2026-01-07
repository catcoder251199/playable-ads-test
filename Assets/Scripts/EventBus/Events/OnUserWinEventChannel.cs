using DefaultNamespace.Game.Enum;
using UnityEngine;

namespace EventBus.Events
{
    public class OnUserWinEventArgs : IEvent
    {
    }
    
    [CreateAssetMenu(fileName = "new OnUserWinEventChannel",
        menuName = "EvenChannels/ OnUserWinEventChannel")]
    public class OnUserWinEventChannel : GenericEventChannelSO<OnUserWinEventArgs>
    {
        
    }
}