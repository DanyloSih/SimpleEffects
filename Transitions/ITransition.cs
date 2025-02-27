namespace SimpleEffects.Transitions
{
    public interface ITransition<TData>
    {
        public TData GetTransition(TransitionData<TData> transitionData);
    }
}