using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace VPopup
{
    public class VPopup : MonoBehaviour
    {
        #region Serialized Section
        [Header("Popup")] [SerializeField] protected string popupName;
        [SerializeField] protected MonoBehaviour animationHandler;
        [SerializeField] protected VCanvas canvasParent;
        [SerializeField] protected CanvasGroup overlayCanvasGroup;
        [SerializeField] protected RectTransform contentRectTransform;

        [SerializeField] protected bool disableOnAwake = true;
        [SerializeField] protected bool enableOverlay = true;
        [SerializeField] protected bool allowInterruptAnimation = false;
        [SerializeField] protected bool disablePopupGameObjectOnAnimationOnHidden = true;
        
        [Header("Events"), SerializeField] protected UnityEvent onPopupOpenBeganEvent;
        [SerializeField] protected UnityEvent onPopupOpenEndedEvent;
        [SerializeField] protected UnityEvent onPopupCloseBeganEvent;
        [SerializeField] protected UnityEvent onPopupCloseEndedEvent;
        
        [Header("private container setting"), SerializeField, ReadOnly] private Vector2 contentInitialAnchorPos;
        [SerializeField, ReadOnly] private Vector3 contentInitialScale;
        [SerializeField, ReadOnly] private float contentInitialAlpha;
        [SerializeField, ReadOnly] private CanvasGroup contentCanvasGroup;
        
        #endregion
    
        #region Interface Section
        protected IPopupAnimationHandler AnimationHandler => (IPopupAnimationHandler) animationHandler;
        #endregion

        public bool IsOpen { get; private set; }
        public bool DisablePopupGameObjectOnAnimationOnHidden => disablePopupGameObjectOnAnimationOnHidden;
        public VCanvas CanvasParent => canvasParent;
        public CanvasGroup OverlayCanvasGroup => overlayCanvasGroup;
        public bool EnableOverlay => enableOverlay;
        public RectTransform ContentRectTransform => contentRectTransform;
        public Vector2 ContentInitialAnchorPos => contentInitialAnchorPos;
        public Vector3 ContentInitialScale => contentInitialScale;
        public float ContentInitialAlpha => contentInitialAlpha;
        public CanvasGroup ContentCanvasGroup => contentCanvasGroup;

        
#if UNITY_EDITOR
        [ContextMenu("Initialize In Editor")]
        private void PrivateInitializeInEditor()
        {
            contentInitialAnchorPos = contentRectTransform.anchoredPosition;
            contentInitialScale = contentRectTransform.localScale;

            contentCanvasGroup = contentRectTransform.GetComponent<CanvasGroup>();
            if (contentCanvasGroup)
            {
                contentInitialAlpha = contentCanvasGroup.alpha;
            }
        }
        
        [ContextMenu("Reset UI back to initial state In Editor")]
        private void ResetUIBackToInitialState()
        {
            contentRectTransform.anchoredPosition = contentInitialAnchorPos;
            contentRectTransform.localScale = contentInitialScale;

            contentCanvasGroup = contentRectTransform.GetComponent<CanvasGroup>();
            if (contentCanvasGroup)
            {
                this.contentCanvasGroup.alpha = contentInitialAlpha;
            }
        }
#endif
        
        private void Awake()
        {
            if (disableOnAwake)
                gameObject.SetActive(false);

            contentInitialAnchorPos = contentRectTransform.anchoredPosition;
        }

        public void PrintMessage(string s) => Debug.Log(s);

        public bool IsAnimating => AnimationHandler != null && AnimationHandler.IsAnimating();
        
        public void Open()
        {
            if (!allowInterruptAnimation && IsAnimating)
            {
                Debug.LogWarning($"{nameof(VPopup)}: Warning: can't animate the popup \"{popupName}\" 's being animated!");
                return;
            }
            
            gameObject.SetActive(true);

            OnOpen();

            if (AnimationHandler != null)
            {
                AnimationHandler.Show(this, OnOpenedInternal);
            }
            else
            {
                if (overlayCanvasGroup && enableOverlay)
                    overlayCanvasGroup.alpha = 1f;

                if (contentRectTransform)
                    contentRectTransform.gameObject.SetActive(true);
                OnOpenedInternal();
            }
        }
        
#if UNITY_EDITOR
        public void ValidatePopup()
        {
            if (!contentRectTransform)
            {
                Debug.LogWarning($"{nameof(contentRectTransform)} is null!");
            }
            else
            {
                if (!contentRectTransform.gameObject.GetComponent<Canvas>())
                {
                    Debug.LogWarning($"{nameof(contentRectTransform)} should have {nameof(Canvas)} component");
                }
                if (!contentRectTransform.gameObject.GetComponent<GraphicRaycaster>())
                {
                    Debug.LogWarning($"{nameof(contentRectTransform)} should have {nameof(GraphicRaycaster)} component");
                }
                if (!contentRectTransform.gameObject.GetComponent<CanvasGroup>())
                {
                    Debug.LogWarning($"{nameof(contentRectTransform)} should have {nameof(CanvasGroup)} component");
                }

                if (!contentCanvasGroup)
                {
                    Debug.LogWarning($"field{nameof(contentCanvasGroup)} should not be null -> please run \"Initialize In Editor\" in context menu");
                }
            }

            if (!overlayCanvasGroup)
            {
                Debug.LogWarning($"{nameof(overlayCanvasGroup)} is null!");
            }
            else
            {
                if (!overlayCanvasGroup.gameObject.GetComponent<Canvas>())
                {
                    Debug.LogWarning($"{nameof(overlayCanvasGroup)} should have {nameof(Canvas)} component");
                } 
                
                if (!overlayCanvasGroup.gameObject.GetComponent<GraphicRaycaster>())
                {
                    Debug.LogWarning($"{nameof(overlayCanvasGroup)} should have {nameof(GraphicRaycaster)} component");
                } 
            }
            
            Debug.Log($"Popup {popupName} validation is done!");
        }
#endif
        
        public void Hide()
        {
            if (!allowInterruptAnimation && IsAnimating)
            {
                Debug.LogWarning($"{nameof(VPopup)}: Warning: can't animate the popup \"{popupName}\" 's being animated!");
                return;
            }
            
            gameObject.SetActive(true);
            
            OnClose();

            if (AnimationHandler != null)
            {
                AnimationHandler.Hide(this, OnClosedInternal);
            }
            else
            {
                if (overlayCanvasGroup && enableOverlay)
                    overlayCanvasGroup.alpha = 0f;

                if (contentRectTransform)
                    contentRectTransform.gameObject.SetActive(false);
            
                gameObject.SetActive(false);
                OnClosedInternal();
            }
        }

        private void OnOpenedInternal()
        {
            IsOpen = true;
            OnOpened();
        }

        private void OnClosedInternal()
        {
            IsOpen = false;
            OnClosed();
        }

        protected virtual void OnOpen()
        {
            onPopupOpenBeganEvent?.Invoke();   
        }

        protected virtual void OnOpened()
        {
            onPopupOpenEndedEvent?.Invoke();   
        }

        protected virtual void OnClose()
        {
            onPopupCloseBeganEvent?.Invoke();   
        }

        protected virtual void OnClosed()
        {
            onPopupCloseEndedEvent?.Invoke();   
        }
    }
}