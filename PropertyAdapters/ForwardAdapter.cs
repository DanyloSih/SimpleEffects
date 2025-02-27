using UnityEngine;

namespace SimpleEffects.PropertyAdapters
{

    public class ForwardAdapter : PropertyAdapter<Vector3>
    {
        public ForwardAdapter(Transform transform)
            : base(() => transform.forward, (x) => transform.forward = x)
        {
        }
    }
}