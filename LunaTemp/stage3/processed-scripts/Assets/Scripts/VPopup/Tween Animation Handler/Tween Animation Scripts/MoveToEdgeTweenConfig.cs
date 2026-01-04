using System;
using DG.Tweening;
using UnityEngine;

namespace VPopup.Tween_Animation_Handler
{
    [CreateAssetMenu(fileName = "new MovePopupToEdgeTweenConfig", menuName = "VPopup/Tween Config/Move Popup To Edge")]
    public class MoveToEdgeTweenConfig : AbstractPopupTweenConfig
    {
        [SerializeField] private ScreenEdge fromEdge = ScreenEdge.Left;
        [SerializeField] private float startDelay = 0f;
        [SerializeField] private float duration = 1f;
        [SerializeField] private Vector2 additionalFromOffset;
        [SerializeField] private Ease ease = Ease.Linear;

        public override Tween CreateTween(VPopup target)
        {
            Vector2 endPosition = CalculateEndPosition(target);
            var contentRectTransform = target.ContentRectTransform;

            return contentRectTransform.DOAnchorPos(endPosition, duration)
                .SetDelay(startDelay)
                .SetEase(ease)
                .Pause();
        }

        private Vector2 CalculateEndPosition(VPopup target)
        {
            var contentRectTransform = target.ContentRectTransform;
            var canvasRectTransform = target.CanvasParent.RectTransform;

            var canvasSize = canvasRectTransform.rect.size;
            var contentSize = contentRectTransform.rect.size;
            var contentBasePosition = contentRectTransform.anchoredPosition;
            switch (fromEdge)
            {
                case ScreenEdge.Left:
                    return new Vector2(-canvasSize.x * 0.5f - contentSize.x * 0.5f - additionalFromOffset.x,
                        contentBasePosition.y);
                case ScreenEdge.Right:
                    return new Vector2(canvasSize.x * 0.5f + contentSize.x * 0.5f + additionalFromOffset.x,
                        contentBasePosition.y);
                case ScreenEdge.Bottom:
                    return new Vector2(contentBasePosition.x, -canvasSize.y * 0.5f - contentSize.y * 0.5f - additionalFromOffset.y);
                case ScreenEdge.Top:
                    return new Vector2(contentBasePosition.x, canvasSize.y * 0.5f + contentSize.y * 0.5f + additionalFromOffset.y);
            }

            return contentBasePosition;
        }
    }
}