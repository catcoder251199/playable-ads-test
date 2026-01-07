using DG.Tweening;
using EventBus.Events;
using UnityEngine;

namespace DefaultNamespace.Game
{
    public class TapTile : Tile
    {
        [SerializeField] private OnUserGainedScoreEventChannel onUserGainedScoreEventChannel;
        [SerializeField] private CanvasGroup bodyCanvasGroup;
        [SerializeField] private float bodyFadeValue = 0.5f;
        [SerializeField] private float bodyFadeDuration = 0.25f;
        [SerializeField] private HeadAnimator headAnimator;
        [SerializeField] private ScoreAnimator scoreAnimator;
        
        private bool isTapped = false;
        
        protected override void OnTileTouchDownEventHandler(OnTileTouchDownEventArgs eventArgs)
        {
            if (noteData == null || noteData.id < 0)
                return;

            if (isTapped || eventArgs.Id != noteData.id)
                return;
            
            isTapped = true;
            onUserGainedScoreEventChannel.RaiseEvent(new OnUserGainedScoreEventArgs(1));
            UpdateUIOnTapped();
        }

        private void UpdateUIOnTapped()
        {
            bodyCanvasGroup.DOFade(0.3f, bodyFadeDuration).SetTarget(bodyCanvasGroup);
            headAnimator.AnimateOnDead();
            scoreAnimator.SetScore(1, true);
        }

        public override void OnSpawn()
        {
            base.OnSpawn();
            isTapped = false;
            DOTween.KillAll(bodyCanvasGroup);
            headAnimator.ResetUI();
            scoreAnimator.ResetUI();
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