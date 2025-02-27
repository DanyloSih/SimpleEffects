namespace SimpleEffects
{
    public class EffectEvents : IEffectEvents
    {
        private OnetimeCallbacks<EffectEndCallback> _effectEndOnetimeCallback = new ();

        public OnetimeCallbacks<EffectEndCallback> EffectEndOnetimeCallbacks { get => _effectEndOnetimeCallback; }

        public event EffectEndCallback EffectEnded;  

        public void Complete()
        {
            _effectEndOnetimeCallback.InvokeOnetime((c) => c?.Invoke(EndCause.Completed));
            EffectEnded?.Invoke(EndCause.Completed);
        }

        public void Stop()
        {
            _effectEndOnetimeCallback.InvokeOnetime((c) => c?.Invoke(EndCause.Stopped));
            EffectEnded?.Invoke(EndCause.Stopped);
        }
    }
}