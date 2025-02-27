using UnityEngine;

namespace SimpleEffects
{
    public class EffectsParallelPack : EffectsPack
    {
        private int _completedEffectsCounter = 0;

        public EffectsParallelPack(params IEffect[] effects) : base(effects)
        {
        }

        public override void Play(MonoBehaviour coroutineExecuter)
        {
            IsPlaying = true;
            _completedEffectsCounter = 0;

            for (int i = 0; i < Effects.Count; i++)
            {
                var effect = Effects[i];
                float initialPlaybackSpeed = effect.PlaybackSpeed;
                effect.PlaybackSpeed *= PlaybackSpeed;
                effect.Events.EffectEndOnetimeCallbacks.Add((x) => effect.PlaybackSpeed = initialPlaybackSpeed);
                effect.Events.EffectEndOnetimeCallbacks.Add(IsCompletedCheck);
                effect.Play(coroutineExecuter);
            }
        }

        public override void Stop()
        {
            if (IsPlaying)
            {
                for (int i = 0; i < Effects.Count; i++)
                {
                    var effect = Effects[i];
                    effect.Stop();
                }

                IsPlaying = false;
                EffectEvents.Stop();
            }
        }

        private void IsCompletedCheck(EndCause endCause)
        {
            _completedEffectsCounter++;

            if (_completedEffectsCounter == Effects.Count)
            {
                EffectEvents.Complete();
            }
        }
    }
}