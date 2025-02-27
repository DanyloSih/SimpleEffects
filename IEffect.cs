using UnityEngine;

namespace SimpleEffects
{

    public enum EndCause
    {
        Completed,
        Stopped
    }

    public delegate void EffectEndCallback(EndCause endCause);

    public interface IEffect
    {
        public bool IsPlaying { get; }
        public IEffectEvents Events { get; }
        public float PlaybackSpeed { get; set; }

        public void Play(MonoBehaviour coroutineExecuter);

        public void Stop();
    }
}