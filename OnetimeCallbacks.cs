using System;
using System.Collections.Generic;

namespace SimpleEffects
{
    public class OnetimeCallbacks<T> where T : System.Delegate
    {
        private List<T> _onetimeEffectEndCallbacks = new List<T>();
        private bool _isInvoking;

        public void Add(T effectEndCallback)
        {
            _onetimeEffectEndCallbacks.Add(effectEndCallback);
        }

        public void Remove(T effectEndCallback)
        {
            _onetimeEffectEndCallbacks.Remove(effectEndCallback);
        }

        public void InvokeOnetime(Action<T> invokeAction)
        {
            List<T> callbacks = new List<T>(_onetimeEffectEndCallbacks);
            _onetimeEffectEndCallbacks.Clear();

            for (int i = 0; i < callbacks.Count; i++)
            {
                T endCallback = callbacks[i];
                invokeAction.Invoke(endCallback);
            }

            callbacks.Clear();
        }
    }
}