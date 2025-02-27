using UnityEngine;

namespace SimpleEffects.Transitions
{

    public class DirectionMoveTowardsTransition : DirectionTransition
    {
        private Config _config;

        public DirectionMoveTowardsTransition(Config config) : base(config)
        {
            _config = config;
        }

        protected override Vector3 GetDirection(TransitionData<Vector3> transitionData, Quaternion from, Quaternion to)
        {
            return Quaternion.RotateTowards(
              from, to, _config.Speed * transitionData.TransitionProgress * Time.deltaTime)
              * Vector3.forward;
        }
    }
}