using System;
using SimpleEffects.PropertyAdapters;
using SimpleEffects.Utilities;

namespace SimpleEffects
{
    public class FloatSetEffect : PropertyEffect<float>
    {
        private FloatEffectConfig _config;

        public FloatSetEffect(FloatEffectConfig config, IPropertyAdapter<float> propertyAdapter) : base(config, propertyAdapter)
        {
            _config = config;
        }

        public override float GetDuration()
        {
            return _config.ValueCurve.GetDuration();
        }

        public override float GetEffectValue(float initialPropertyData, float effectProgress)
        {
            return _config.ValueCurve.Evaluate(effectProgress);
        }
    }
}