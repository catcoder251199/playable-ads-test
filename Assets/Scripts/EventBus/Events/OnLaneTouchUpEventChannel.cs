using DefaultNamespace.Game;
using UnityEngine;

namespace EventBus.Events
{
    public class OnLaneTouchUpEventArgs : IEvent
    {
        private int laneIndex;
        public int LaneIndex => laneIndex;
        public OnLaneTouchUpEventArgs(int laneIndex)
        {
            this.laneIndex = laneIndex;
        }
    }
    
    [CreateAssetMenu(fileName = "new OnLaneTouchUpEventChannel",
        menuName = "EvenChannels/ OnLaneTouchUpEventChannel")]
    public class OnLaneTouchUpEventChannel : GenericEventChannelSO<OnLaneTouchUpEventArgs>
    {
    }
}