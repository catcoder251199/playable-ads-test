using System;
using DG.Tweening;
using UnityEngine;

namespace VPopup.Tween_Animation_Handler
{
    [CreateAssetMenu(fileName = "new FadeFromTweenConfig", menuName = "VPopup/Tween Config/Fade Popup From")]
    public class FadeFromTweenConfig : AbstractPopupTweenConfig
    {
        [SerializeField, Range(0, 1)] private float fadeFrom;
        [SerializeField] private float startDelay = 0f;
        [SerializeField] private float duration = 1f;
        [SerializeField] private Ease ease = Ease.Linear;

        public override Tween CreateTween(VPopup target)
        {
            var contentCanvasGroup = target.ContentCanvasGroup;
            if (!contentCanvasGroup)
            {
                Debug.LogError($"{nameof(FadeFromTweenConfig)} can't find content's canvas group!");
                return null;
            }
            
            var endValue = target.ContentInitialAlpha;
            contentCanvasGroup.alpha = fadeFrom;
            return contentCanvasGroup.DOFade(endValue, duration)
                .SetDelay(startDelay)
                .SetEase(ease)
                .Pause();
        }
    }
}