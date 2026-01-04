using System;
using System.Collections;
using System.Collections.Generic;
using EventBus;
using UnityEngine;

public class UnitA : MonoBehaviour
{
    public SOSEventChannel sosEventChannel;
    public void DetectSomethingHappened()
    {
        var evtArgs = new HelpMeEventArgs();
        evtArgs.message = "Help Me";

        sosEventChannel?.OnEventRaised(evtArgs);
    }
}
