namespace SimpleEffects.Transitions
{
    public struct TransitionData<TData>
    {
        public TData InitialValue;
        public TData CurrentValue;
        public TData TargetValue;
        public float TransitionProgress;
        public float MaxDuration;
    }
}