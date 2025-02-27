using SimpleEffects.PropertyAdapters;
using SimpleEffects.Utilities;
using SimpleEffects.Transitions;
using UnityEngine;
using System;

namespace SimpleEffects
{
    public class TransitionEffect<TData> : PropertyEffect<TData>
    {
        [Serializable]
        public new class Config : PropertyEffect<TData>.Config
        {
            [Tooltip("X - effect progress. \nY - transition progress.")]
            public AnimationCurve TransitionProgress;
            public float Duration;
            public bool SnapCurveTimeToDuration;

            public float Evaluate(float progress)
            {
                return TransitionProgress.Evaluate(
                    SnapCurveTimeToDuration 
                    ? Mathf.Lerp(0, TransitionProgress.GetDuration(), progress) 
                    : progress * Duration);
            }
        }

        private Config _config;
        private IPropertyAdapter<TData> _lerpingAdapter;
        private IPropertyGetter<TData> _targetGetter;
        private ITransition<TData> _transition;

        public TransitionEffect(
            Config config,
            IPropertyAdapter<TData> lerpingAdapter,
            IPropertyGetter<TData> targetGetter,
            ITransition<TData> transition) 
            : base(config, lerpingAdapter)
        {
            _config = config;
            _lerpingAdapter = lerpingAdapter;
            _targetGetter = targetGetter;
            _transition = transition;
        }

        public override float GetDuration()
        {
            return _config.Duration;
        }

        public override TData GetEffectValue(TData initialPropertyData, float effectProgress)
        {
            TransitionData<TData> transitionData = new TransitionData<TData>()
            {
                InitialValue = initialPropertyData,
                CurrentValue = _lerpingAdapter.GetData(),
                TargetValue = _targetGetter.GetData(),
                TransitionProgress = _config.Evaluate(effectProgress),
                MaxDuration = GetDuration()
            };

            return _transition.GetTransition(transitionData);
        }
    }
}