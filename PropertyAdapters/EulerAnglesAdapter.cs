using UnityEngine;

namespace SimpleEffects.PropertyAdapters
{
    public class EulerAnglesAdapter : PropertyAdapter<Vector3>
    {
        public EulerAnglesAdapter(Transform transform)
            : base(() => transform.eulerAngles, (x) => transform.eulerAngles = x)
        {
        }
    }
}