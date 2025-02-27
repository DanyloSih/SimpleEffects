using UnityEngine;

namespace SimpleEffects.Transitions
{
    public class Vector3LerpTransition : ITransition<Vector3>
    {
        public Vector3 GetTransition(TransitionData<Vector3> transitionData)
        {
            return Vector3.Lerp(
                transitionData.InitialValue, 
                transitionData.TargetValue, 
                transitionData.TransitionProgress);
        }
    }
}