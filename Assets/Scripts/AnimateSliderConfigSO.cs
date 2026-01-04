using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Slider Animation Config", menuName = "My SO/Slider Animation Config")]
public class AnimateSliderConfigSO : ScriptableObject
{
    public float moveDuration = 1f;
    public float moveRewardDuration = 1f;
    public float scaleRewardDuration = 1f;
    public float rotateRewardDuration = 1f;
    public float rotateRewardStartTime = 1f;
    public float rewardRotateCycle = 1f;
    public float scaleRewardValue = 2f;
    public AnimationCurve moveCurve;
    public AnimationCurve rewardMoveCurve;
    public AnimationCurve rewardScaleCurve;
    public AnimationCurve rewardRotateCurve;
}
