using System;
using DefaultNamespace.Game.Enum;
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
        private void Update()
        {
            if (!gameObject.activeSelf || noteData.duration == 0 || isDead)
                return;

            var yToWall = YToWall();
            if (yToWall <= 0 && !isHit)
            {
                isHit = true;
                Debug.Log($"Hit the wall {noteData.id}");
                onUserLoseEventChannel.OnEventRaised?.Invoke(new OnUserLoseEventArgs(LoseReason.TileHitWall));
                return;
            }
        }

        protected override void OnUserLoseEventHandler(OnUserLoseEventArgs eventArgs)
        {
            headAnimator.AnimateOnUserLose();
        }

        
        protected override void OnTileTouchDownEventHandler(OnTileTouchDownEventArgs eventArgs)
        {
            if (noteData == null || noteData.id < 0)
                return;

            if (isTapped || eventArgs.Id != noteData.id)
                return;

            isDead = true;
            isTapped = true;
            var rateLevel = CalculateRateLevel();
            onUserGainedScoreEventChannel.RaiseEvent(new OnUserGainedScoreEventArgs(1, rateLevel));
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
            isDead = false;
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