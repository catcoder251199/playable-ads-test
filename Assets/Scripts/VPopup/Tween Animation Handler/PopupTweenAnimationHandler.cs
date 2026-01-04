using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace VPopup.Tween_Animation_Handler
{
    public class PopupTweenAnimationHandler : MonoBehaviour, IPopupAnimationHandler
    {
        [Header("Show/Hide animation"),SerializeField] private ScriptableObject tweenShowAnimationConfig;
        [SerializeField] private ScriptableObject tweenHideAnimationConfig;
        [SerializeField] private float showAnimationDelay = 0;
        [SerializeField] private float hideAnimationDelay = 0;
        [SerializeField] private UnityEvent onShowAnimationBeganEvent;
        [SerializeField] private UnityEvent onShowAnimationEndedEvent;
        [SerializeField] private UnityEvent onHideAnimationBeganEvent;
        [SerializeField] private UnityEvent onHideAnimationEndedEvent;

        [Header("Overlay animation"), SerializeField] private Ease overlayEase = Ease.Linear;
        
        private Tween _tween;
        
        private AbstractPopupTweenConfig TweenShowAnimationConfig => tweenShowAnimationConfig as AbstractPopupTweenConfig;
        private AbstractPopupTweenConfig TweenHideAnimationConfig => tweenHideAnimationConfig as AbstractPopupTweenConfig;

        public bool IsAnimating() => _tween.IsActive() && _tween.IsPlaying();

        public void Show(VPopup vPopup, Action onComplete)
        {
            var tweenConfig = TweenShowAnimationConfig;

            if (_tween.IsActive())
            {
                _tween.Kill();
            }

            if (vPopup.ContentRectTransform)
            {
                vPopup.ContentRectTransform.gameObject.SetActive(true);
            }

            bool overlayIsAnimatable = vPopup.OverlayCanvasGroup && vPopup.EnableOverlay;
            if (overlayIsAnimatable)
            {
                vPopup.OverlayCanvasGroup.gameObject.SetActive(true);
            }

            if (!tweenConfig) // No animation
            {
                if (vPopup.OverlayCanvasGroup && vPopup.EnableOverlay)
                    vPopup.OverlayCanvasGroup.alpha = 1f;
                
                onComplete?.Invoke();
                return;
            }

            var createdTween = tweenConfig.CreateTween(vPopup).SetLoops(1);
            var sequence = DOTween.Sequence().AppendInterval(showAnimationDelay).Append(createdTween);

            if (overlayIsAnimatable)
            {
                var overlayDuration = createdTween.Duration();
                Debug.Log($"overlay show duration {overlayDuration}!");
                sequence.Join(vPopup.OverlayCanvasGroup.DOFade(1f, overlayDuration));
            }
            
            _tween = sequence.SetAutoKill(true)
                .SetLink(vPopup.gameObject, LinkBehaviour.CompleteOnDisable)
                .OnPlay(() =>
                {
                    onShowAnimationBeganEvent?.Invoke();
                })
                .OnComplete(() =>
                {
                    _tween = null;
                    onShowAnimationEndedEvent?.Invoke();
                    onComplete?.Invoke();
                })
                .OnKill(()=> _tween = null)
                .Play();
        }

        public void Hide(VPopup vPopup, Action onComplete)
        {
            var tweenConfig = TweenHideAnimationConfig;

            if (_tween.IsActive())
            {
                _tween.Kill();
            }
            
            if (!tweenConfig) // No animation
            {
                if (vPopup.ContentRectTransform)
                    vPopup.ContentRectTransform.gameObject.SetActive(false);
                if (vPopup.OverlayCanvasGroup && vPopup.EnableOverlay)
                    vPopup.OverlayCanvasGroup.alpha = 0f;
                
                onComplete?.Invoke();
                return;
            }

            var createdTween = tweenConfig.CreateTween(vPopup).SetLoops(1);
            var sequence = DOTween.Sequence().AppendInterval(hideAnimationDelay).Append(createdTween);
            
            if (vPopup.OverlayCanvasGroup && vPopup.EnableOverlay)
            {
                var overlayDuration = createdTween.Duration();
                Debug.Log($"overlay hide duration {overlayDuration}!");
                sequence.Join(vPopup.OverlayCanvasGroup.DOFade(0f, overlayDuration));
            }
            
            _tween = sequence.SetAutoKill(true)
                .SetLink(vPopup.gameObject, LinkBehaviour.CompleteOnDisable)
                .OnPlay(() =>
                {
                    onHideAnimationBeganEvent?.Invoke();
                })
                .OnComplete(() =>
                {
                    if (vPopup.DisablePopupGameObjectOnAnimationOnHidden)
                        vPopup.gameObject.SetActive(false);
                    onHideAnimationEndedEvent?.Invoke();
                    onComplete?.Invoke();
                })
                .OnKill(()=> _tween = null)
                .Play();
        }
    }
}