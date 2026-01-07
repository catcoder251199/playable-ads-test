using System;
using DefaultNamespace.Game.Enum;
using DG.Tweening;
using EventBus.Events;
using UnityEngine;

namespace DefaultNamespace.Game
{
    public class PageMover : MonoBehaviour
    {
        [SerializeField] protected OnUserLoseEventChannel onUserLoseEventChannel;
        [SerializeField] private LevelDataSO levelDataSO;
        [SerializeField] private TilePage[] pages;
        [SerializeField] private bool _updateable = false;

        public void SetMoveable(bool moveable) => _updateable = moveable;

        private void OnEnable()
        {
            onUserLoseEventChannel.OnEventRaised += OnUserLoseHandler;
        }
        
        private void OnDisable()
        {
            onUserLoseEventChannel.OnEventRaised -= OnUserLoseHandler;
        }

        private void OnUserLoseHandler(OnUserLoseEventArgs eventArgs)
        {
            if (eventArgs.Reason != LoseReason.TileHitWall)
            {
                _updateable = false;
                return;
            }
            _updateable = false;
            JumpBack();
        }

        private void JumpBack()
        {
            foreach (var page in pages)
            {
                RectTransform rect = page.RectTransform;
                float jumpBackOffset = 50f;
                float duration = 0.3f;

                Vector2 startPos = rect.anchoredPosition;
                rect.anchoredPosition = startPos;
                rect.DOAnchorPosY(startPos.y + jumpBackOffset, duration)
                    .SetEase(Ease.OutBack);
            }
        }

        private void Update()
        {
            if (!_updateable)
                return;

            foreach (var page in pages)
            {
                page.UpdateY(levelDataSO.TilesVelocity);
            }
        }
    }
}