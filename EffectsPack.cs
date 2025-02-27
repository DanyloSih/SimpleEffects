using System.Collections.Generic;
using UnityEngine;

namespace SimpleEffects
{
    public abstract class EffectsPack : IEffect
    {
        private List<IEffect> _effects;
        private float _playbackSpeed = 1;
        private bool _isReversed = false;

        protected EffectEvents EffectEvents = new EffectEvents();

        public IReadOnlyList<IEffect> Effects { get => _effects;  }
        public IEffectEvents Events { get => EffectEvents; }
        public bool IsPlaying { get; protected set; }
        public float PlaybackSpeed
        {
            get => _playbackSpeed;
            set
            {
                _playbackSpeed = value;
                _isReversed = value < 0;
            }
        }
        public bool IsReversed { get => _isReversed; }

        public EffectsPack(params IEffect[] effects)
        {
            _effects = new List<IEffect>();

            foreach (IEffect effect in effects)
            {
                _effects.Add(effect);
            }
        }

        /// <summary>
        /// Adds an effect to the sequence and returns its identifier.
        /// </summary>
        public int AddEffect(IEffect effect)
        {
            _effects.Add(effect);
            return _effects.Count - 1;
        }

        public void RemoveEffect(int effectId)
        {
            _effects.RemoveAt(effectId);
        }

        public abstract void Play(MonoBehaviour coroutineExecuter);
        public abstract void Stop();
    }
}