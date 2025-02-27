using System;
using UnityEngine;

namespace SimpleEffects.PropertyAdapters
{
    public class PositionAdapter : PropertyAdapter<Vector3>
    {
        public PositionAdapter(Transform transform) 
            : base(() => transform.position, (x) => transform.position = x)
        {
        }
    }
}