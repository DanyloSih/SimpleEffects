using System;

namespace SimpleEffects.PropertyAdapters
{
    public class PropertyAdapter<TData> : IPropertyAdapter<TData>
    {
        private Func<TData> _getDataMethod;
        private Action<TData> _setDataMethod;

        public PropertyAdapter(Func<TData> getDataMethod, Action<TData> setDataMethod)
        {
            _getDataMethod = getDataMethod;
            _setDataMethod = setDataMethod;
        }

        public TData GetData()
        {
            return _getDataMethod.Invoke();
        }

        public void SetData(TData data)
        {
            _setDataMethod.Invoke(data);
        }
    }
}