using System;
using System.Collections;
using System.Collections.Generic;
using EventBus;
using UnityEngine;


[Serializable]
public struct HelpMeEventArgs : IEvent
{
    public int priority;
    public string message;
}

[CreateAssetMenu(fileName = "new SOSEventChannel", menuName = "Event Channel SO/SOSEventChannel")]
public class SOSEventChannel : GenericEventChannelSO<HelpMeEventArgs>
{}
