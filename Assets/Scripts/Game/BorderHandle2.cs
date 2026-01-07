using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;



namespace DefaultNamespace.Game
{
    public class BorderHandler2 : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private CanvasGroup borderCanvasGroup;
        [SerializeField] private Image borderImage;
        [SerializeField] private float blinkDuartion = 1f;

        [Header("Colors")] [SerializeField] private Color[] colors;
        private int _currentColorIndex = 0;
        
        private Tween tween;

        public void StartBlink()
        {
            borderCanvasGroup.gameObject.SetActive(true);
            // tween.Kill();
            // borderCanvasGroup.alpha = 0f;
            // tween = borderCanvasGroup
            //     .DOFade(1f, blinkDuartion)
            //     .SetEase(Ease.InOutSine)
            //     .SetLoops(-1, LoopType.Yoyo)
            //     .SetAutoKill(false)
            //     .OnKill(() => Debug.Log("Blink is killed!!!"));
        }

        public void StopBlink()
        {
            borderCanvasGroup.gameObject.SetActive(false);
            // if (tween != null && tween.IsActive())
            //     tween.Kill();
            //
            // borderCanvasGroup.alpha = 0f;
        }

        public void OnReachFirstStar()
        {
            if (!gameObject.activeSelf)
                gameObject.SetActive(true);
            StartBlink();
            ChangeColor();
            //borderCanvasGroup.DOFade(1f, 0.5f);
        }

        public void OnReachStar()
        {
            ChangeColor();
        }
        
        private void ChangeColor()
        {
            if (colors == null || colors.Length == 0) return;

            borderImage.color = colors[_currentColorIndex];

            _currentColorIndex = (_currentColorIndex + 1) % colors.Length;
        }
    }
}