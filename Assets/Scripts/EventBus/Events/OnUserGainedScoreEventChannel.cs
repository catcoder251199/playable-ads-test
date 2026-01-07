using DefaultNamespace.Game.Enum;
using UnityEngine;

namespace EventBus.Events
{
    public class OnUserGainedScoreEventArgs : IEvent
    {
        public int Score { get; }
        public RateLevel RateLevel { get; } 

        public OnUserGainedScoreEventArgs(int score, RateLevel rateLevel)
        {
            Score = score;
            RateLevel = rateLevel;
        }
    }
    
    [CreateAssetMenu(fileName = "new OnUserGainedScoreEventChannel",
        menuName = "EvenChannels/ OnUserGainedScoreEventChannel")]
    public class OnUserGainedScoreEventChannel : GenericEventChannelSO<OnUserGainedScoreEventArgs>
    {
        
    }
}