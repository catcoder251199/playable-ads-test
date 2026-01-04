using System;
using System.Collections;
using System.Collections.Generic;
using EventBus;
using UnityEngine;

public class UnitC : MonoBehaviour
{
    public SOSEventChannel SosEventChannel;
    public void OnEnable()
    {
        SosEventChannel.OnEventRaised += OnSomethingHappenedEventHandler;
    }
    
    public void OnDisable()
    {
        SosEventChannel.OnEventRaised -= OnSomethingHappenedEventHandler;
    }

    private void OnSomethingHappenedEventHandler(HelpMeEventArgs evtArgs)
    {
        Debug.Log($"Unit C Update UI with message {evtArgs.message}");
    }
}