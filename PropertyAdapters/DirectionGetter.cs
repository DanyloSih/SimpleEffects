using System;
using UnityEngine;

namespace SimpleEffects.PropertyAdapters
{
    public class DirectionGetter : IPropertyGetter<Vector3>
    {
        [Serializable]
        public class Config
        {
            public Vector3 TargetOffset;
        }

        private Config _сonfig;
        private Transform _from;
        private Transform _to;

        public DirectionGetter(Config сonfig, Transform from, Transform to)
        {
            _from = from;
            _to = to;
            _сonfig = сonfig;
        }

        public Vector3 GetData()
        {
            return ((_to.position + _сonfig.TargetOffset) - _from.position).normalized;
        }
    }
}