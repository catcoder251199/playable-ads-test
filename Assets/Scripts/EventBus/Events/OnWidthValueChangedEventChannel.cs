using UnityEngine;

namespace EventBus.Events
{
    [CreateAssetMenu(fileName = "new OnWidthValueChangedEventArgs", menuName = "EvenChannels/ OnWidthValueChangedEventArgs")]
    public class OnWidthValueChangedEventChannel<T> : GenericEventChannelSO<OnValueChangedFromToEventArgs<T, float>>
    {}
}