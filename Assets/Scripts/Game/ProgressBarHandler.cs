using System;
using DG.Tweening;
using EventBus.Events;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.Game
{
    public class ProgressBarHandler : MonoBehaviour
    {
        [SerializeField] private LevelDataSO levelData;
        [SerializeField] private OnUserProgressChangedEventChannel onUserProgressChangedEventChannel;
        [SerializeField] private Slider slider;
        [SerializeField] private int starAmount = 6;
        [SerializeField] private RectTransform[] startRects;
        [SerializeField] private Image[] StarImages;
        [SerializeField] private BorderHandler borderHandler;
        [SerializeField] private Color starColor = Color.yellow;
        //[SerializeField] private RectTransform handle;

        private bool reachedFirstStar = false;
        private int _starGained = 0;

        private void Awake()
        {
            slider.value = 0;
            slider.maxValue = 1;
            reachedFirstStar = false;
            _starGained = 0;
        }
        
        #if UNITY_EDITOR
        private int testedTappedTotal = 0;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                testedTappedTotal += 1;
                OnUserProgressChangedEventHandler(
                    new OnUserProgressChangedEventArgs(testedTappedTotal, levelData.LevelData.Count));
            }
        }
        #endif

        private void OnEnable()
        {
            onUserProgressChangedEventChannel.OnEventRaised += OnUserProgressChangedEventHandler;
            // handle.localScale = Vector3.one;
            // handle.DOScale(1.1f, 0.25f)
            //     .SetEase(Ease.InOutSine)
            //     .SetLoops(-1, LoopType.Yoyo);
        }
        
        private void OnDisable()
        {
            onUserProgressChangedEventChannel.OnEventRaised -= OnUserProgressChangedEventHandler;
            // handle.DOKill();
        }

        private void OnUserProgressChangedEventHandler(OnUserProgressChangedEventArgs eventArgs)
        {
            var oldT = slider.value;
            var t = (float) eventArgs.TappedTotal / eventArgs.TileTotal;
            
            if (reachedFirstStar)
            {
                borderHandler.OnScoreGained();
            }
            
            if (t > oldT)
            {
                slider.value = t;
                
                var nextStarT = (_starGained + 1f) / starAmount;
                if (oldT < nextStarT && t >= nextStarT)
                {
                    DoAnimateStar(_starGained);
                    if (!reachedFirstStar && _starGained == 0)
                    {
                        borderHandler.OnReachFirstStar();
                        reachedFirstStar = true;
                    }
                    
                    _starGained += 1;
                }
            }
        }

        private void DoAnimateStar(int starIndex)
        {
            if (starIndex < 0 || starIndex >= starAmount)
                return;
            var startRect = startRects[starIndex];
            var starImage = StarImages[starIndex];
            starImage.color = starColor;
            DOTween.Sequence()
                .Append(startRect.DOScale(2f, 0.05f))
                .Append(startRect.DOScale(1.5f, 0.2f));
        }
    }
}