using DefaultNamespace.Game;
using UnityEngine;

namespace EventBus.Events
{
    public class OnLaneTouchDownEventArgs : IEvent
    {
        private int laneIndex;
        public int LaneIndex => laneIndex;

        public OnLaneTouchDownEventArgs(int laneIndex)
        {
            this.laneIndex = laneIndex;
        }
    }
    
    [CreateAssetMenu(fileName = "new OnLaneTouchDownEventChannel",
        menuName = "EvenChannels/ OnLaneTouchDownEventChannel")]
    public class OnLaneTouchDownEventChannel : GenericEventChannelSO<OnLaneTouchDownEventArgs>
    {
    }
}