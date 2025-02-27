using System;
using System.Collections;
using UnityEngine;

namespace SimpleEffects
{
    public abstract class Effect : IEffect
    {
        [Serializable]
        public class Config
        {
            public float PlaybackSpeed = 1f;
        }

        private Coroutine _coroutine;
        private EffectEvents _effectEvents = new EffectEvents();
        private Config _config;

        protected Effect(Config config)
        {
            _config = config;
        }

        public float PlaybackSpeed
        {
            get => _config.PlaybackSpeed;
            set => _config.PlaybackSpeed = value;
        }
        public bool IsPlaying { get => _coroutine != null; }   
        public IEffectEvents Events { get => _effectEvents; }

        protected MonoBehaviour CoroutineExecutor { get; private set; }

        public void Play(MonoBehaviour coroutineExecuter)
        {
            Stop();
            CoroutineExecutor = coroutineExecuter;
            _coroutine = coroutineExecuter.StartCoroutine(Process());
        }

        public void Stop()
        {
            if (IsPlaying)
            {            
                CoroutineExecutor?.StopCoroutine(_coroutine);
                OnStop();
                _coroutine = null;
                _effectEvents.Stop();
            }
        }

        protected abstract IEnumerator OnPlay();

        private IEnumerator Process()
        {
            yield return OnPlay();
            _coroutine = null;
            _effectEvents.Complete();
        }

        protected virtual void OnStop() { }
    }
}