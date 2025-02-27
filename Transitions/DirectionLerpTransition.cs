using UnityEngine;

namespace SimpleEffects.Transitions
{
    public class DirectionLerpTransition : DirectionTransition
    {
        private Config _config;

        public DirectionLerpTransition(Config config) : base(config)
        {
            _config = config;
        }

        protected override Vector3 GetDirection(TransitionData<Vector3> transitionData, Quaternion from, Quaternion to)
        {
            return Quaternion.Lerp(
              from, to, _config.Speed * transitionData.TransitionProgress * Time.deltaTime)
              * Vector3.forward;
        }
    }
}