using System;
using System.Collections;
using SimpleEffects.PropertyAdapters;
using UnityEngine;

namespace SimpleEffects
{

    public abstract class PropertyEffect<TData> : Effect
    {
        [Serializable]
        public new class Config : Effect.Config
        {
            [Tooltip("If true, then the value of the affected property will " +
                "be reset to its initial value after the effect ends.")]
            public bool ResetValue;
        }

        private Config _config;
        private IPropertyAdapter<TData> _propertyAdapter;
        private TData _initialPropertyData;

        protected PropertyEffect(Config config, IPropertyAdapter<TData> propertyAdapter) : base(config)
        {
            _config = config;
            _propertyAdapter = propertyAdapter;
        }

        protected override IEnumerator OnPlay()
        {
            float timer = 0;
            float duration = GetDuration();
            _initialPropertyData = _propertyAdapter.GetData();
            float absPlaybackSpeed = Mathf.Abs(PlaybackSpeed);
            bool isReverse = PlaybackSpeed < 0;

            while (timer < duration)
            {
                yield return new WaitForEndOfFrame();
                timer += Time.deltaTime * absPlaybackSpeed;
                float progress = timer / duration;
                if (isReverse)
                {
                    progress = 1 - progress;
                }

                _propertyAdapter.SetData(GetEffectValue(_initialPropertyData, progress));
            }

            ResetValue();
        }

        protected override void OnStop()
        {
            ResetValue();
        }

        private void ResetValue()
        {
            if (_config.ResetValue)
            {
                _propertyAdapter.SetData(_initialPropertyData);
            }
        }

        public abstract float GetDuration();
        public abstract TData GetEffectValue(TData initialPropertyData, float effectProgress);
    }
}