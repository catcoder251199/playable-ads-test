using DefaultNamespace.Game;
using UnityEngine;

namespace EventBus.Events
{
    public class OnTilePageRecycledEventArgs : IEvent
    {
        public TilePage TilePage { get; }
        public OnTilePageRecycledEventArgs(TilePage tilePage) => TilePage = tilePage;
    }
    
    [CreateAssetMenu(fileName = "new OnTilePageRecycledEventChannel", menuName = "EvenChannels/ OnTilePageRecycledEventChannel")]
    public class OnTilePageRecycledEventChannel : GenericEventChannelSO<OnTilePageRecycledEventArgs>
    {}
}