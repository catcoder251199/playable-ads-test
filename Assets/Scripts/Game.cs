using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;

public class Game : MonoBehaviour
{
    [Header("DoTween setup")] [SerializeField]
    private bool recycleAllByDefault = true;

    [SerializeField] private bool useSafeMode = false;
    [SerializeField] private LogBehaviour logBehaviour = LogBehaviour.Default;
    
    
    [SerializeField] private Character character;
    
    private void Start()
    {
        DOTween.Init(recycleAllByDefault, useSafeMode, logBehaviour);
    }
}
