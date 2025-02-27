using UnityEngine;

namespace SimpleEffects
{
    public class EffectsSequence : EffectsPack
    {
        private MonoBehaviour _coroutineExecuter;

        public int PlayingEffectId { get; private set; }

        public EffectsSequence(params IEffect[] effects) : base(effects)
        {
        }

        public override void Play(MonoBehaviour coroutineExecuter)
        {
            _coroutineExecuter = coroutineExecuter;
            IsPlaying = true;
            PlayingEffectId = IsReversed ? Effects.Count : -1;
            EffectEndHandler(EndCause.Completed);
        }

        public override void Stop()
        {
            foreach (var effect in Effects)
            {
                effect.Stop();
            }
        }

        private void EffectEndHandler(EndCause endCause)
        {
            bool isEffectIdInsideBounds = IsReversed ? PlayingEffectId - 1 >= 0 : PlayingEffectId + 1 < Effects.Count;

            if (endCause == EndCause.Completed && isEffectIdInsideBounds)
            {
                PlayingEffectId += IsReversed ? -1 : 1;
                var effect = Effects[PlayingEffectId];

                float initialPlaybackSpeed = effect.PlaybackSpeed;
                effect.PlaybackSpeed *= PlaybackSpeed;
                effect.Events.EffectEndOnetimeCallbacks.Add(EffectEndHandler);
                effect.Events.EffectEndOnetimeCallbacks.Add((x) => effect.PlaybackSpeed = initialPlaybackSpeed);
                effect.Play(_coroutineExecuter);
            }
            else if (endCause == EndCause.Stopped)
            {
                EffectEvents.Stop();
                IsPlaying = false;
            }
            else if(!isEffectIdInsideBounds)
            {
                EffectEvents.Complete();
            }
        }
    }
}