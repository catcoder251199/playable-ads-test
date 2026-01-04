using System;
using DG.Tweening;
using UnityEngine;

namespace VPopup.Tween_Animation_Handler
{
    [CreateAssetMenu(fileName = "new FadeToTweenConfig", menuName = "VPopup/Tween Config/Fade Popup To")]
    public class FadeToTweenConfig : AbstractPopupTweenConfig
    {
        [SerializeField, Range(0, 1)] private float fadeTo;
        [SerializeField] private float startDelay = 0f;
        [SerializeField] private float duration = 1f;
        [SerializeField] private Ease ease = Ease.Linear;

        public override Tween CreateTween(VPopup target)
        {
            var contentCanvasGroup = target.ContentCanvasGroup;
            if (!contentCanvasGroup)
            {
                Debug.LogError($"{nameof(FadeToTweenConfig)} can't find content's canvas group!");
                return null;
            }
            
            return contentCanvasGroup.DOFade(fadeTo, duration)
                .SetDelay(startDelay)
                .SetEase(ease)
                .Pause();
        }
    }
}