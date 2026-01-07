using UnityEngine;

namespace EventBus.Events
{
    public class OnTileTouchUpEventArgs : IEvent
    {
        private int id;

        public OnTileTouchUpEventArgs(int id)
        {
            this.id = id;
        }
    }
    
    [CreateAssetMenu(fileName = "new OnTileTouchUpEventChannel",
        menuName = "EvenChannels/ OnTileTouchUpEventChannel")]
    public class OnTileTouchUpEventChannel : GenericEventChannelSO<OnTileTouchUpEventArgs>
    {
    }
}