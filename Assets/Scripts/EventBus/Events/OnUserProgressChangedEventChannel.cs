using DefaultNamespace.Game;
using UnityEngine;

namespace EventBus.Events
{
    public class OnUserProgressChangedEventArgs : IEvent
    {
        public int TappedTotal { get; }
        public int TileTotal { get; }
        
        public OnUserProgressChangedEventArgs(int tappedTotal, int tileTotal)
        {
            TappedTotal = tappedTotal;
            TileTotal = tileTotal;
        }
    }
    
    [CreateAssetMenu(fileName = "new OnUserProgressChangedEventChannel",
        menuName = "EvenChannels/ OnUserProgressChangedEventChannel")]
    public class OnUserProgressChangedEventChannel : GenericEventChannelSO<OnUserProgressChangedEventArgs>
    {
    }
}