using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace DefaultNamespace.Game.BackgroundSpawner
{
    public class UIFloatingItem : MonoBehaviour
    {
        [Header("Refs")]
        [SerializeField] private RectTransform rect;
        [SerializeField] private CanvasGroup canvasGroup;

        [Header("Move")]
        [SerializeField] private float moveDistanceMin = 40f;
        [SerializeField] private float moveDistanceMax = 80f;
        [SerializeField] private float moveDuration = 3f;

        [Header("Wiggle")]
        [SerializeField] private float wiggleStrength = 6f;
        [SerializeField] private float wiggleDuration = 0.3f;

        [Header("Disappear")]
        [SerializeField] private float fadeDuration = 0.6f;

        private Sequence seq;
        private UIFloatingSpawner owner;

        [ContextMenu("start float")]
        private void DoPlay()
        {
            Play(null);
        }
        
        public void Play(UIFloatingSpawner spawner)
        {
            owner = spawner;

            rect.localScale = Vector3.one;
            canvasGroup.alpha = 1f;

            Vector2 dir = Random.insideUnitCircle.normalized;
            float dist = Random.Range(moveDistanceMin, moveDistanceMax);
            Vector2 targetPos = rect.anchoredPosition + dir * dist;

            seq = DOTween.Sequence();

            // Move
            canvasGroup.alpha = 0f;
            seq.Append(rect.DOAnchorPos(targetPos, moveDuration).SetEase(Ease.Linear));
            seq.Join(canvasGroup.DOFade(0.5f, moveDuration * 0.5f));
            seq.Insert(moveDuration * 0.75f, canvasGroup.DOFade(0f, fadeDuration));
            seq.Insert(moveDuration * 0.5f, rect.DOScale(0.6f, fadeDuration));

            seq.OnComplete(Despawn);
        }

        void Despawn()
        {
            seq?.Kill();
            if (owner != null)
                owner.Release(this);
        }
    }

}