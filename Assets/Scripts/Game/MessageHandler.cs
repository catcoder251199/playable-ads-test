using DefaultNamespace.Game.Enum;
using TMPro;
using UnityEngine;
using DG.Tweening;
using EventBus.Events;

namespace DefaultNamespace.Game
{
    public class MessageHandler : MonoBehaviour
    {
        [Header("Events")] [SerializeField] private OnUserLoseEventChannel onUserLoseEventChannel;
        [Header("Events")] [SerializeField] private OnUserWinEventChannel onUserWinEventChannel;
        
        [Header("References")]
        [SerializeField] private TextMeshProUGUI loseText;

        [Header("Tween Settings")]
        [SerializeField] private float showDuration = 0.3f;
        [SerializeField] private float stayDuration = 2.0f;
        [SerializeField] private float hideDuration = 0.25f;
        [SerializeField] private Vector3 showScale = Vector3.one;
        [SerializeField] private Vector3 hiddenScale = Vector3.one * 0.8f;

        private Tween currentTween;

        private void Awake()
        {
            loseText.gameObject.SetActive(false);
        }
        
#if UNITY_EDITOR
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                OnUseLoseEventHandler(new OnUserLoseEventArgs(LoseReason.TileHitWall));
            }
            
            if (Input.GetKeyDown(KeyCode.S))
            {
                OnUseLoseEventHandler(new OnUserLoseEventArgs(LoseReason.TooSoon));
            }
            
            if (Input.GetKeyDown(KeyCode.D))
            {
                OnUseLoseEventHandler(new OnUserLoseEventArgs(LoseReason.WrongTile));
            }
            
            if (Input.GetKeyDown(KeyCode.F))
            {
                OnUserWinEventHandler(new OnUserWinEventArgs());
            }
        }
#endif

        private void OnEnable()
        {
            onUserWinEventChannel.OnEventRaised += OnUserWinEventHandler;
            onUserLoseEventChannel.OnEventRaised += OnUseLoseEventHandler;
        }
        
        private void OnDisable()
        {
            onUserWinEventChannel.OnEventRaised -= OnUserWinEventHandler;
            onUserLoseEventChannel.OnEventRaised -= OnUseLoseEventHandler;
        }

        private void OnUserWinEventHandler(OnUserWinEventArgs eventArgs)
        {
            ShowLoseReason(GetSuccessMessage());
        }
        
        private void OnUseLoseEventHandler(OnUserLoseEventArgs eventArgs)
        {
            ShowLoseReason(GetLoseMessage(eventArgs.Reason));
        }

        private void ShowLoseReason(string message)
        {
            

            currentTween?.Kill();

            loseText.text = message;
            loseText.alpha = 0f;
            loseText.transform.localScale = hiddenScale;
            loseText.gameObject.SetActive(true);

            currentTween = DOTween.Sequence()
                // Show
                .Append(loseText.DOFade(1f, showDuration))
                .Join(loseText.transform.DOScale(showScale, showDuration).SetEase(Ease.OutBack))
                // Stay
                .AppendInterval(stayDuration)
                // Hide
                .Append(loseText.DOFade(0f, hideDuration))
                .Join(loseText.transform.DOScale(hiddenScale, hideDuration).SetEase(Ease.InBack))
                .OnComplete(() =>
                {
                    loseText.gameObject.SetActive(false);
                });
        }

        private string GetLoseMessage(LoseReason reason)
        {
            switch (reason)
            {
                case LoseReason.TooSoon:
                    return "<color=#FF5C5C>Tap to soon</color>";
                case LoseReason.WrongTile:
                    return "<color=#FFA500>Tap wrong tile</color>";
                case LoseReason.TileHitWall:
                    return "<color=#FF8C00>Too slow</color>";
                default:
                    return "Game Over";
            }
        }

        private string GetSuccessMessage() => "Finish";
    }
}