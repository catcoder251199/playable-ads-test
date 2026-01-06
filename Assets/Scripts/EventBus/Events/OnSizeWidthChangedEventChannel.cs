using DefaultNamespace.Game;
using UnityEngine;

namespace EventBus.Events
{
    [CreateAssetMenu(fileName = "new OnSizeWidthChangedEventChannel", menuName = "EvenChannels/ OnSizeWidthChangedEventChannel")]
    public class OnSizeWidthChangedEventChannel : OnWidthValueChangedEventChannel<SizeEventNotifier> {}
}