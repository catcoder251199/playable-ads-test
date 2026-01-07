using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.Game
{
    public class HeadAnimator : MonoBehaviour
    {
        [SerializeField, Header("Head")] private Sprite aliveHeadSprite;
        [SerializeField] private Sprite deadHeadSprite;
        [SerializeField] private Image headImage;
        [SerializeField] private RectTransform headRectTransform;
        [SerializeField] private float happyAngle = 20f;
        [SerializeField] private float deathAngle = 30f;

        private Tween _tween;
        
#if UNITY_EDITOR
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                ResetUI();
                AnimateOnDead();
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                ResetUI();
                AnimateOnUserLose();
            }
        }
#endif

        public void ResetUI()
        {
            _tween.Kill();
            
            headImage.sprite = aliveHeadSprite;
            headRectTransform.rotation = Quaternion.identity;
        }

        public void AnimateOnDead()
        {
            headImage.sprite = deadHeadSprite;
            _tween.Kill();
            _tween = DOTween.Sequence()
                .Append(headRectTransform.DORotate(new Vector3(0, 0, deathAngle), 0.5f)).SetTarget(headRectTransform);
        }

        public void AnimateOnUserLose()
        {
            headImage.sprite = aliveHeadSprite;
            
            _tween.Kill();
            
            headRectTransform.localRotation = Quaternion.Euler(0, 0, -happyAngle);
            _tween = headRectTransform
                .DOLocalRotate(new Vector3(0, 0, happyAngle), 0.5f)
                .SetEase(Ease.InOutSine)
                .SetLoops(-1, LoopType.Yoyo).SetTarget(gameObject);
        }
    }
}