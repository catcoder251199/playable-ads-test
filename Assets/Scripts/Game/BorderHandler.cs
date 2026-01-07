using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;



namespace DefaultNamespace.Game
{
    public class BorderHandler : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private CanvasGroup borderCanvasGroup;
        [SerializeField] private Image borderImage;
        [SerializeField] private Material material;

        [Header("Pulse Config")]
        [SerializeField] private float basePulseSpeed = 1f;
        [SerializeField] private float impulsePulse = 0.6f;
        [SerializeField] private float maxPulseBoost = 3f;
        [SerializeField] private float returnDuration = 0.4f;

        [Header("Colors")] [SerializeField] private Color[] colors;
        private int _currentColorIndex = 0;
        
        private Material runtimeMat;
        private Tween pulseTween;

        private float currentPulseSpeed;


        void Awake()
        {
            runtimeMat = Instantiate(material);
            borderImage.material = runtimeMat;

            currentPulseSpeed = basePulseSpeed;
            runtimeMat.SetFloat("_PulseSpeed", currentPulseSpeed);
        }
        
        public void OnReachFirstStar()
        {
            gameObject.SetActive(true);
            ChangeColor();
            borderCanvasGroup.DOFade(1f, 0.5f);
        }

        public void OnReachStar()
        {
            ChangeColor();
        }
        
        private void ChangeColor()
        {
            if (colors == null || colors.Length == 0) return;

            runtimeMat.color = colors[_currentColorIndex];

            _currentColorIndex = (_currentColorIndex + 1) % colors.Length;
        }

        public void OnScoreGained()
        {
            PushPulse();
            EnsureReturnTween();
        }

        private void PushPulse()
        {
            currentPulseSpeed = Mathf.Min(
                currentPulseSpeed + impulsePulse,
                basePulseSpeed + maxPulseBoost
            );

            runtimeMat.SetFloat("_PulseSpeed", currentPulseSpeed);
        }

        private void EnsureReturnTween()
        {
            pulseTween?.Kill();

            pulseTween = DOTween.To(
                    () => currentPulseSpeed,
                    x =>
                    {
                        currentPulseSpeed = x;
                        runtimeMat.SetFloat("_PulseSpeed", x);
                    },
                    basePulseSpeed,
                    returnDuration
                )
                .SetEase(Ease.OutExpo)
                .SetUpdate(true); // optional: ignore timescale
        }

        void OnDestroy()
        {
            if (runtimeMat != null)
                Destroy(runtimeMat);
        }
    }
}