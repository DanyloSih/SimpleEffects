using System;
using SimpleEffects.PropertyAdapters;
using UnityEngine;

namespace SimpleEffects
{
    public class Vector3ShiftEffect : Vector3SetEffect
    {
        private Vector3EffectConfig _config;

        public Vector3ShiftEffect(Vector3EffectConfig config, IPropertyAdapter<Vector3> propertyAdapter) : base(config, propertyAdapter)
        {
            _config = config;
        }

        public override Vector3 GetEffectValue(Vector3 initialPropertyData, float effectProgress)
        {
            return base.GetEffectValue(initialPropertyData, effectProgress) + initialPropertyData;
        }
    }
}