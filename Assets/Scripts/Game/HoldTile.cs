using DG.Tweening;
using EventBus.Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.Game
{
    public class HoldTile : Tile
    {
        [SerializeField] private LevelDataSO levelDataSo;
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

        private void Update()
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
        }

        private void OnPlayerGainedScore(int fromScore, int toScore, bool isMaxed)
        {
            Debug.Log($"User gained score + {toScore - fromScore}");
            onUserGainedScoreEventChannel.RaiseEvent(new OnUserGainedScoreEventArgs(toScore - fromScore));
            scoreAnimator.SetScore(toScore, isMaxed);
        }

        private void OnReachedMaxScore(int maxScore)
        {
            headAnimator.AnimateOnDead();
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
            
            isTapped = true;
            holdTapTime = 0;
            UpdateUIOnTapped();
        }

        private void UpdateUIOnTapped()
        {
            bodyCanvasGroup.DOFade(0.3f, bodyFadeDuration).SetTarget(bodyCanvasGroup);
        }

        public override void OnSpawn()
        {
            base.OnSpawn();
            isTapped = false;
            
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