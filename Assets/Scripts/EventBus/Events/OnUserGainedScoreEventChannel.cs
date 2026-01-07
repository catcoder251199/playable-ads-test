using UnityEngine;

namespace EventBus.Events
{
    public class OnUserGainedScoreEventArgs : IEvent
    {
        public int Score { get; }

        public OnUserGainedScoreEventArgs(int score)
        {
            Score = score;
        }
    }
    
    [CreateAssetMenu(fileName = "new OnUserGainedScoreEventChannel",
        menuName = "EvenChannels/ OnUserGainedScoreEventChannel")]
    public class OnUserGainedScoreEventChannel : GenericEventChannelSO<OnUserGainedScoreEventArgs>
    {
        
    }
}