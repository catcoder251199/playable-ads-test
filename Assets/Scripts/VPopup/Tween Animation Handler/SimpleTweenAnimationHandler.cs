using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using VPopup;

public class SimpleTweenAnimationHandler : MonoBehaviour, IPopupAnimationHandler
{
    [SerializeField] private RectTransform root;
    [SerializeField] private Image overlay;

    private Tween _tween;
    
    private void Awake()
    {
        _tween = root.DOScale(1f, 0.3f)
            .From(0f)
            .SetEase(Ease.InOutBack)
            .SetAutoKill(false)
            .Pause()
            .SetLink(gameObject);
    }

    public bool IsAnimating() => _tween.IsActive() && !_tween.IsPlaying();

    public void Show(VPopup.VPopup vPopup, Action onComplete)
    {
        _tween.OnComplete(() =>
        {
            onComplete?.Invoke();
        });
        _tween.PlayForward();
    }

    public void Hide(VPopup.VPopup vPopup, Action onComplete)
    {
        _tween.OnRewind(() =>
        {
            onComplete?.Invoke();
        });
        _tween.PlayBackwards();
    }
}
