using System;
using DG.Tweening;
using UnityEngine;

namespace VPopup.Tween_Animation_Handler
{
    [CreateAssetMenu(fileName = "new ScalePopupFromTweenConfig", menuName = "VPopup/Tween Config/Scale Popup From")]
    public class ScaleFromTweenConfig : AbstractPopupTweenConfig
    {
        [SerializeField] private Vector3 scaleFrom;
        [SerializeField] private float startDelay = 0f;
        [SerializeField] private float duration = 1f;
        [SerializeField] private Ease ease = Ease.Linear;

        public override Tween CreateTween(VPopup target)
        {
            var contentRectTransform = target.ContentRectTransform;
            Vector3 endValue = target.ContentInitialScale;
            
            Vector3 startValue = scaleFrom;
            contentRectTransform.localScale = startValue;
            
            return contentRectTransform.DOScale(endValue, duration)
                .SetDelay(startDelay)
                .SetEase(ease)
                .Pause();
        }
    }
}