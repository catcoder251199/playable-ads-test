using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderAnimator : MonoBehaviour
{
    [SerializeField, Header("Slider")] private Slider slider;
    [SerializeField] private RectTransform handle;
    [SerializeField] private RectTransform reward;
    [SerializeField] private AnimateSliderConfigSO animationConfig;
    
    [SerializeField] private float currentValue = 0;
    [SerializeField] private float maxValue = 10;
    private void Start()
    {
        slider.value = currentValue;
        slider.maxValue = maxValue;
        slider.wholeNumbers = false;
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            DoAnimateSliderForward();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            DoAnimateSliderBackward();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Print();
        }
    }

    private Tween _tween;
    private void DoAnimateSliderForward()
    {
        if (_tween != null)
        {
            if (_tween.IsBackwards())
                _tween.PlayForward();
            else
            {
                _tween.PlayBackwards();
            }
            return;
        }

        _tween = CreateTweenForSlider();
    }

    private Tween CreateTweenForSlider()
    {
        slider.value = 0;
        reward.localPosition = new Vector2(reward.localPosition.x, 0f);
        reward.localScale = Vector3.one;
        reward.localRotation = Quaternion.identity;
        Sequence sequence = DOTween.Sequence();
        sequence.AppendCallback(() =>
            {
                Debug.Log("Sequence Start");
                // init...
            })
            .Append(slider.DOValue(slider.maxValue, animationConfig.moveDuration).SetEase(animationConfig.moveCurve))
            .AppendCallback(() =>
            {
                Debug.Log("Move End");
            })
            .Append(reward.DOAnchorPosY(reward.anchoredPosition.y + 200f, animationConfig.moveRewardDuration).SetEase(animationConfig.rewardMoveCurve))
            .Join(reward.DOScale(animationConfig.scaleRewardValue, animationConfig.scaleRewardDuration).SetEase(animationConfig.rewardScaleCurve))
            .Insert(animationConfig.rotateRewardStartTime, reward.DORotate(animationConfig.rewardRotateCycle * 360 * Vector3.forward, animationConfig.rotateRewardDuration, RotateMode.FastBeyond360).SetEase(animationConfig.rewardRotateCurve))
            .OnComplete(() =>
            {
                Debug.Log("Sequence completed!");
            }).OnKill(()=>Debug.Log("Sequence killed!"))
            .OnRewind(()=>Debug.Log("Sequence rewind!"))
            .OnStepComplete(()=>Debug.Log("Step completed!"));
        sequence.SetAutoKill(false);
        //sequence.SetLoops(-1, LoopType.Yoyo);
        return sequence;
    }

    private Tween _t;
    private void DoAnimateSliderBackward()
    {
        
    }

    private void Print()
    {
        Destroy(gameObject);
    }
}
