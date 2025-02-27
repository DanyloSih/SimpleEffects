using System;
using UnityEngine;

namespace SimpleEffects
{
    [Serializable]
    public class FloatEffectConfig : PropertyEffect<float>.Config
    {
        public AnimationCurve ValueCurve;
    }
}