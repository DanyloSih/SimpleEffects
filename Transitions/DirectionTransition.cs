using System;
using UnityEngine;

namespace SimpleEffects.Transitions
{
    public abstract class DirectionTransition : ITransition<Vector3>
    {
        [Serializable]
        public class Config
        {
            public Vector3 Upwards = Vector3.up;
            public float Speed = 50f;
        }

        private Config _config;

        public DirectionTransition(Config config)
        {
            _config = config;
        }

        public Vector3 GetTransition(TransitionData<Vector3> transitionData)
        {
            Quaternion from = Quaternion.LookRotation(transitionData.CurrentValue, _config.Upwards);
            Quaternion to = Quaternion.LookRotation(transitionData.TargetValue, _config.Upwards);
            return GetDirection(transitionData, from, to);
        }

        protected abstract Vector3 GetDirection(TransitionData<Vector3> transitionData, Quaternion from, Quaternion to);
    }
}