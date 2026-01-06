using DefaultNamespace.Game;
using UnityEngine;

namespace EventBus.Events
{
    [CreateAssetMenu(fileName = "new OnLaneWidthChangedEventChannel", menuName = "EvenChannels/ OnLaneWidthChangedEventChannel")]
    public class OnLaneWidthChangedEventChannel : OnWidthValueChangedEventChannel<Lane> {}
}