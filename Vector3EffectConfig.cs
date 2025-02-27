using System;
using SimpleEffects.Utilities;
using UnityEngine;

namespace SimpleEffects
{
    [Serializable]
    public class Vector3EffectConfig : PropertyEffect<Vector3>.Config
    {
        public AnimationCurve XValueCurve;
        public AnimationCurve YValueCurve;
        public AnimationCurve ZValueCurve;
        public Vector3 Scale;
        public float Duration;
        public bool SnapCurveTimeToDuration;

        public Vector3 Evaluate(float progress) 
            => new (EvaluateX(progress), EvaluateY(progress), EvaluateZ(progress));

        public float EvaluateX(float progress) 
            => Evaluate(XValueCurve, progress) * Scale.x;

        public float EvaluateY(float progress) 
            => Evaluate(YValueCurve, progress) * Scale.y;

        public float EvaluateZ(float progress) 
            => Evaluate(ZValueCurve, progress) * Scale.z;

        private float Evaluate(AnimationCurve curve, float progress)
        {
            return curve.Evaluate(SnapCurveTimeToDuration ? Mathf.Lerp(0, curve.GetDuration(), progress) : progress * Duration);
        }
    }
}