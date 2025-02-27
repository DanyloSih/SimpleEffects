using SimpleEffects.PropertyAdapters;
using UnityEngine;

namespace SimpleEffects
{
    public class Vector3SetEffect : PropertyEffect<Vector3>
    {
        private Vector3EffectConfig _config;

        public Vector3SetEffect(Vector3EffectConfig config, IPropertyAdapter<Vector3> propertyAdapter) : base(config, propertyAdapter)
        {
            _config = config;
        }

        public override float GetDuration()
        {
            return _config.Duration;
        }

        public override Vector3 GetEffectValue(Vector3 initialPropertyData, float effectProgress)
        {
            return _config.Evaluate(effectProgress);
        }
    }
}