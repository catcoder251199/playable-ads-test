using System;
using UnityEngine;

namespace VPopup
{
    public class AnimatorPopupAnimationHandler 
        : MonoBehaviour, IPopupAnimationHandler
    {
        [Header("Animator")]
        [SerializeField] private Animator animator;

        [Header("State Names")]
        [SerializeField] private string showStateName = "Show";
        [SerializeField] private string hideStateName = "Hide";

        private bool _isAnimating;
        private Action _pendingOnComplete;
        private int _currentStateHash;

        void Awake()
        {
            if (animator == null)
                animator = GetComponent<Animator>();

            _currentStateHash = 0;
        }

        public bool IsAnimating()
        {
            return _isAnimating;
        }

        public void Show(VPopup vPopup, Action onComplete)
        {
            PlayState(showStateName, onComplete);
        }

        public void Hide(VPopup vPopup, Action onComplete)
        {
            PlayState(hideStateName, onComplete);
        }

        void PlayState(string stateName, Action onComplete)
        {
            if (animator == null)
            {
                onComplete?.Invoke();
                return;
            }

            gameObject.SetActive(true);

            _isAnimating = true;
            _pendingOnComplete = onComplete;

            _currentStateHash = Animator.StringToHash(stateName);

            animator.Play(stateName, 0, 0f);
            StartCoroutine(WaitForStateEnd());
        }

        System.Collections.IEnumerator WaitForStateEnd()
        {
            // wait for animator enter the state
            yield return null;

            while (true)
            {
                var stateInfo = animator.GetCurrentAnimatorStateInfo(0);

                if (stateInfo.shortNameHash == _currentStateHash &&
                    stateInfo.normalizedTime >= 1f)
                {
                    break;
                }

                yield return null;
            }

            _isAnimating = false;

            _pendingOnComplete?.Invoke();
            _pendingOnComplete = null;

            var stateInfo2 = animator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo2.shortNameHash == Animator.StringToHash(hideStateName))
                gameObject.SetActive(false);
        }
    }
}
