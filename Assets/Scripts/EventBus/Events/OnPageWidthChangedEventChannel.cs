using DefaultNamespace.Game;
using UnityEngine;

namespace EventBus.Events
{
    [CreateAssetMenu(fileName = "new OnPageWidthChangedEventChannel", menuName = "EvenChannels/ OnPageWidthChangedEventChannel")]
    public class OnPageWidthChangedEventChannel : OnWidthValueChangedEventChannel<TilePage> {}
}