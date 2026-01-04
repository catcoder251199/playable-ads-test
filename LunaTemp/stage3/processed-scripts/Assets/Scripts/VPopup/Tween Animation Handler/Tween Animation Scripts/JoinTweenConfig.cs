using System;
using DG.Tweening;
using UnityEngine;

namespace VPopup.Tween_Animation_Handler
{
    [CreateAssetMenu(fileName = "new JoinTweenConfig", menuName = "VPopup/Tween Config/Join Tweens")]
    public class JoinTweenConfig : AbstractPopupTweenConfig
    {
        [SerializeField] private ScriptableObject[] tweenList;
        [SerializeField] private float startDelay = 0f;

        public override Tween CreateTween(VPopup target)
        {
            var sequence = DOTween.Sequence().AppendInterval(startDelay);
            foreach (var rawTween in tweenList)
            {
                var tween = rawTween as AbstractPopupTweenConfig;
                if (tween == null)
                {
                    Debug.LogWarning($"Can't join this tween");
                    continue;
                }

                sequence.Join(tween.CreateTween(target)).Pause();
            }

            return sequence;
        }
    }
}