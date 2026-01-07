using System;
using DefaultNamespace.Game.Enum;
using DG.Tweening;
using EventBus.Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.Game
{
    public class RatePlayerAnimator : MonoBehaviour
    {
        [SerializeField] private OnUserGainedScoreEventChannel onUserGainedScoreEventChannel;
        
        [SerializeField] private RectTransform scoreRectTransform;
        [SerializeField] private TextMeshProUGUI scoreTMP;
        [SerializeField] private Image rateImage;
        [SerializeField] private Sprite _perfectSprite;
        [SerializeField] private Sprite _greatSprite;
        [SerializeField] private Sprite _goodSprite;

        private int _score = 0;
        private RateLevel _currentRateLevel = RateLevel.None;
        private Tween _tween;

        private void Awake()
        {
            _score = 0;
            _currentRateLevel = RateLevel.None;
            scoreRectTransform.gameObject.SetActive(false);
        }
        
        private void OnEnable()
        {
            onUserGainedScoreEventChannel.OnEventRaised += OnUserGainedScoreEventHandler;
        }

        private void OnDisable()
        {
            onUserGainedScoreEventChannel.OnEventRaised -= OnUserGainedScoreEventHandler;
        }

        private void OnUserGainedScoreEventHandler(OnUserGainedScoreEventArgs eventArgs)
        {
            _score += eventArgs.Score;
            if (!scoreRectTransform.gameObject.activeSelf)
                scoreRectTransform.gameObject.SetActive(true);

            scoreTMP.text = $"x{_score}";

            if (_currentRateLevel != eventArgs.RateLevel)
            {
                _currentRateLevel = eventArgs.RateLevel;
                UpdateRateImage(eventArgs.RateLevel);
            }

            DoAnimate();
        }
        
        private void DoAnimate()
        {
            _tween.Kill();
            _tween = DOTween.Sequence()
                .Append(scoreRectTransform.DOScale(1.5f, 0.05f))
                .Append(scoreRectTransform.DOScale(1f, 0.2f));
        }

        private void UpdateRateImage(RateLevel rateLevel)
        {
            switch (rateLevel)
            {
                case RateLevel.Good:
                    rateImage.sprite = _goodSprite;
                    break;
                case RateLevel.Great:
                    rateImage.sprite = _greatSprite;
                    break;
                case RateLevel.Perfect:
                    rateImage.sprite = _perfectSprite;
                    break;
            }
        }

#if UNITY_EDITOR
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
                OnUserGainedScoreEventHandler(new OnUserGainedScoreEventArgs(123, RateLevel.Good));
            if (Input.GetKeyDown(KeyCode.S))
                OnUserGainedScoreEventHandler(new OnUserGainedScoreEventArgs(456, RateLevel.Great));
            if (Input.GetKeyDown(KeyCode.D))
                OnUserGainedScoreEventHandler(new OnUserGainedScoreEventArgs(789, RateLevel.Perfect));
        }
#endif
    }
}