using UnityEngine;

namespace SimpleEffects.Transitions
{
    public class Vector3SetTargetValueTransition : ITransition<Vector3>
    {
        public Vector3 GetTransition(TransitionData<Vector3> transitionData)
        {
            return transitionData.TargetValue;
        }
    }
}