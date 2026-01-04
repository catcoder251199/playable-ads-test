using System;
using DG.Tweening;
using UnityEngine;

namespace VPopup.Tween_Animation_Handler
{
    [CreateAssetMenu(fileName = "new ScalePopupToTweenConfig", menuName = "VPopup/Tween Config/Scale Popup To")]
    public class ScaleToTweenConfig : AbstractPopupTweenConfig
    {
        [SerializeField] private Vector3 scaleTo;
        [SerializeField] private float startDelay = 0f;
        [SerializeField] private float duration = 1f;
        [SerializeField] private Ease ease = Ease.Linear;

        public override Tween CreateTween(VPopup target)
        {
            var contentRectTransform = target.ContentRectTransform;
            return contentRectTransform.DOScale(scaleTo, duration)
                .SetDelay(startDelay)
                .SetEase(ease)
                .Pause();
            
            Vector3 endValue = target.ContentInitialScale;
        }
    }
}