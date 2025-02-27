using SimpleEffects.PropertyAdapters;

namespace SimpleEffects
{
    public class FloatShiftEffect : FloatSetEffect
    {
        private FloatEffectConfig _config;

        public FloatShiftEffect(FloatEffectConfig config, IPropertyAdapter<float> propertyAdapter) : base(config, propertyAdapter)
        {
            _config = config;
        }

        public override float GetEffectValue(float initialPropertyData, float effectProgress)
        {
            return base.GetEffectValue(initialPropertyData, effectProgress) + initialPropertyData;
        }
    }
}