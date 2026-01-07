using DG.Tweening;
using EventBus.Events;
using UnityEngine;

namespace DefaultNamespace.Game
{
    public class StartTile : Tile
    {
        [SerializeField] private CanvasGroup bodyCanvasGroup;
        [SerializeField] private float bodyFadeValue = 0.5f;
        [SerializeField] private float bodyFadeDuration = 0.25f;
        [SerializeField] private HeadAnimator headAnimator;
        [SerializeField] private RectTransform handGuide;

        private bool isTapped = false;
        
        protected override void OnTileTouchDownEventHandler(OnTileTouchDownEventArgs eventArgs)
        {
            handGuide.gameObject.SetActive(false);
            
            if (noteData == null || noteData.id < 0)
                return;

            if (isTapped || eventArgs.Id != noteData.id)
                return;
            isDead = true;
            isTapped = true;
            UpdateUIOnTapped();
        }

        private void UpdateUIOnTapped()
        {
            headAnimator.AnimateOnDead();
            bodyCanvasGroup.DOFade(0.3f, bodyFadeDuration).SetTarget(bodyCanvasGroup);
        }

        public override void OnSpawn()
        {
            base.OnSpawn();
            isDead = false;
            isTapped = false;
            DOTween.KillAll(bodyCanvasGroup);
            headAnimator.ResetUI();
            bodyCanvasGroup.alpha = 1;
        }

        public override void OnDespawn()
        {
            base.OnDespawn();
            DOTween.KillAll(bodyCanvasGroup);
        }

        protected override void OnTileTouchUpEventHandler(OnTileTouchUpEventArgs eventArgs)
        {}
    }
}