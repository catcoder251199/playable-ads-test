using UnityEngine;
using UnityEngine.Events;

namespace EventBus
{
    public abstract class GenericEventChannelSO<T> : ScriptableObject where T : IEvent
    {
        [Tooltip("The action to perform; Listeners subscribe to this UnityAction")]
        public UnityAction<T> OnEventRaised;

        public void RaiseEvent(T parameter)
        {
            OnEventRaised?.Invoke(parameter);
        }
    }
}