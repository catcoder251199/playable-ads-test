using DefaultNamespace.Game.Enum;
using DG.Tweening;
using EventBus.Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.Game
{
    public class HoldTile : Tile
    {
        [SerializeField] private OnUserGainedScoreEventChannel onUserGainedScoreEventChannel;
        [SerializeField] private CanvasGroup bodyCanvasGroup;
        [SerializeField] private float bodyFadeValue = 0.5f;
        [SerializeField] private float bodyFadeDuration = 0.25f;
        [SerializeField] private Slider slider;
        [SerializeField] private HeadAnimator headAnimator;
        [SerializeField] private ScoreAnimator scoreAnimator;
        
        private bool isTapped = false;
        private float holdTapTime = 0f;
        private int tappedScore = 0;
        private RateLevel _rateLevel = RateLevel.None;
        
        protected override void OnUserLoseEventHandler(OnUserLoseEventArgs eventArgs)
        {
            headAnimator.AnimateOnUserLose();
        }

        protected void Update()
        {
            var scaledDuration = levelDataSo.ScaledDuration(noteData.id);
            if (isTapped && holdTapTime < scaledDuration)
            {
                if (Time.deltaTime < 0.2f)
                {
                    holdTapTime += Time.deltaTime;
                    bool reachedMax = holdTapTime >= scaledDuration;
                    float t = Mathf.Clamp01(holdTapTime / scaledDuration);
                   
                    // Update slider
                    UpdateSlider(t);
                    
                    // Check score is increased
                    var score = levelDataSo.HoldScore(holdTapTime);
                    if (score > tappedScore)
                    {
                        OnPlayerGainedScore(tappedScore, score, reachedMax);
                        tappedScore = score;
                    }
                    
                    
                    if (reachedMax)
                    {
                        OnReachedMaxScore(score);
                    }
                }
            }
            
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

        private void OnPlayerGainedScore(int fromScore, int toScore, bool isMaxed)
        {
            Debug.Log($"User gained score + {toScore - fromScore}");
            onUserGainedScoreEventChannel.RaiseEvent(new OnUserGainedScoreEventArgs(toScore - fromScore, _rateLevel));
            scoreAnimator.SetScore(toScore, isMaxed);
        }

        private void OnReachedMaxScore(int maxScore)
        {
            headAnimator.AnimateOnDead();
            scoreAnimator.SetScore(maxScore, true);
        }

        private void UpdateSlider(float t)
        {
            slider.value = t;
        }

        protected override void OnTileTouchDownEventHandler(OnTileTouchDownEventArgs eventArgs)
        {
            if (noteData == null || noteData.id < 0)
                return;

            if (isTapped || eventArgs.Id != noteData.id)
                return;
            
            isDead = true;
            isTapped = true;
            _rateLevel = CalculateRateLevel();
            holdTapTime = 0;
            _rateLevel = RateLevel.None;
            UpdateUIOnTapped();
        }

        private void UpdateUIOnTapped()
        {
            bodyCanvasGroup.DOFade(0.3f, bodyFadeDuration).SetTarget(bodyCanvasGroup);
        }

        public override void OnSpawn()
        {
            base.OnSpawn();
            _rateLevel = RateLevel.None;
            isTapped = false;
            isDead = false;
            // reset slider
            slider.value = 0;
            // reset body
            DOTween.KillAll(bodyCanvasGroup);
            bodyCanvasGroup.alpha = 1;
            // reset tmp
            scoreAnimator.ResetUI();
            // reset head
            headAnimator.ResetUI();
            
            // reset hold time and score
            holdTapTime = 0;
            tappedScore = 0;
        }
        
        public override void OnDespawn()
        {
            base.OnDespawn();
            DOTween.KillAll(bodyCanvasGroup);
        }

        protected override void OnTileTouchUpEventHandler(OnTileTouchUpEventArgs eventArgs)
        {
            isTapped = false;
        }
    }
}