using System;
using System.Collections;
using System.Collections.Generic;
using EventBus;
using UnityEngine;

public class UnitB : MonoBehaviour
{
    public void OnReceiveSOSEvent(HelpMeEventArgs evtArgs)
    {
        Debug.Log($"Unit B listen to {evtArgs.message} ");
    }
}