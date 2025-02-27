using UnityEngine;

namespace SimpleEffects.PropertyAdapters
{
    public class LocalScaleAdapter : PropertyAdapter<Vector3>
    {
        public LocalScaleAdapter(Transform transform)
            : base(() => transform.localScale, (x) => transform.localScale = x)
        {
        }
    }
}