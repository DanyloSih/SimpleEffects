using System;
using System.Collections;
using UnityEngine;

namespace SimpleEffects
{
    public class DelayEffect : Effect
    {
        [Serializable]
        public new class Config : Effect.Config
        {
            public float Delay = 1f;
        }

        private Config _config;

        public DelayEffect(Config config) : base(config)
        {
            _config = config;
        }

        public DelayEffect(float delay, float playbackSpeed) : base(playbackSpeed) 
        {
            _config = new Config() { Delay = delay, PlaybackSpeed = 1f };
        }

        protected override IEnumerator OnPlay()
        {
            yield return new WaitForSeconds(_config.Delay);
        }
    }
}