using UnityEngine;

namespace VPopup
{
    public class VCanvas : MonoBehaviour
    {
        [SerializeField] private RectTransform rectTransform;
        public RectTransform RectTransform => rectTransform;
    }
}