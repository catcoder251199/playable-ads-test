using DG.Tweening;
using TMPro;
using UnityEngine;

namespace DefaultNamespace.Game
{
    public class ScoreAnimator : MonoBehaviour
    {
        [SerializeField] private RectTransform scoreTMPRectTransform;
        [SerializeField] private TextMeshProUGUI scoreTMP;
        [SerializeField] private Color maxScoreColor;

        private Tween _scaleTMPTween;
        
#if UNITY_EDITOR
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
                SetScore(123, false);
            if (Input.GetKeyDown(KeyCode.D))
                SetScore(999, true);
        }
#endif

        public void ResetUI()
        {
            scoreTMP.gameObject.SetActive(false);
            _scaleTMPTween.Kill();
            scoreTMP.color = Color.white;
            scoreTMPRectTransform.localScale = Vector3.one;
        }

        public void SetScore(int score, bool isMax)
        {
            if (!scoreTMP.gameObject.activeSelf)
                scoreTMP.gameObject.SetActive(true);

            scoreTMP.text = $"+{score.ToString()}";
            
            if (isMax)
                scoreTMP.color = maxScoreColor;
            else
                scoreTMP.color = Color.white;
            
            _scaleTMPTween.Kill();
            _scaleTMPTween = DOTween.Sequence()
                .Append(scoreTMPRectTransform.DOScale(1.5f, 0.05f))
                .Append(scoreTMPRectTransform.DOScale(1f, 0.2f));
        }
    }
}