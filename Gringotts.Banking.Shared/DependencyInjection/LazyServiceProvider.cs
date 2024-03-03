namespace Gringotts.Banking.Shared.DependencyInjection;

using Microsoft.Extensions.DependencyInjection;


public class LazyServiceProvider<T> where T : class
{
    private readonly Func<T> _valueFactory;

    private T? _value;

    public LazyServiceProvider(IServiceProvider serviceProvider)
    {
        _valueFactory = () => serviceProvider.GetRequiredService<T>();
    }

    public T Value
    {
        get
        {
            if (_value == null)
                _value = _valueFactory();
            return _value;
        }
    }
}
