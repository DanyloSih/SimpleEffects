namespace SimpleEffects.PropertyAdapters
{
    public interface IPropertyAdapter<TData> : IPropertyGetter<TData>, IPropertySetter<TData>
    {
    }
}