using System;

namespace VPopup
{
    public interface IPopupAnimationHandler
    {
        bool IsAnimating();
        void Show(VPopup vPopup, Action onComplete);
        void Hide(VPopup vPopup, Action onComplete);
    }
}