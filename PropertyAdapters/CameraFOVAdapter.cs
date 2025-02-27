using UnityEngine;

namespace SimpleEffects.PropertyAdapters
{
    public class CameraFOVAdapter : PropertyAdapter<float>
    {
        public CameraFOVAdapter(Camera camera)
            : base(() => camera.fieldOfView, (x) => camera.fieldOfView = x)
        {
        }
    }
}