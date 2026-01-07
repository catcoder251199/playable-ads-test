using DefaultNamespace.Game;
using UnityEngine;

namespace EventBus.Events
{
    public class OnTileTouchDownEventArgs : IEvent
    {
        private int id;
        public int Id => id;
        public OnTileTouchDownEventArgs(int id)
        {
            this.id = id;
        }
    }
    
    [CreateAssetMenu(fileName = "new OnTileTouchDownEventChannel",
        menuName = "EvenChannels/ OnTileTouchDownEventChannel")]
    public class OnTileTouchDownEventChannel : GenericEventChannelSO<OnTileTouchDownEventArgs>
    {
    }
}