namespace SimpleEffects
{
    public interface IEffectEvents
    {
        public OnetimeCallbacks<EffectEndCallback> EffectEndOnetimeCallbacks { get; }

        public event EffectEndCallback EffectEnded;
    }
}