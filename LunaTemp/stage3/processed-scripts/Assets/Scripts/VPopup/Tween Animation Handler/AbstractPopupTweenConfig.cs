using System;
using DG.Tweening;
using UnityEngine;

namespace VPopup.Tween_Animation_Handler
{
    public abstract class AbstractPopupTweenConfig : ScriptableObject
    {
        public abstract Tween CreateTween(VPopup target);
    }
}
