using DefaultNamespace.Game;
using EventBus.Events;

namespace EventBus.Listeners
{
    public class OnWidthChangedListener : AbstractEventChannelListener<OnWidthValueChangedEventChannel<SizeEventNotifier>, OnValueChangedFromToEventArgs<SizeEventNotifier, float>>
    {}
}