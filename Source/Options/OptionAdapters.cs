using System;

namespace Proxoft.Extensions.Options;

public static class OptionExtensions
{
    public static Option<T> When<T>(this T value, Func<T, bool> predicate)
    {
        return predicate(value) ? new Some<T>(value) : None.Instance;
    }

    public static Option<T> When<T>(this T value, bool condition)
    {
        return condition ? new Some<T>(value) : None.Instance;
    }

    public static Option<T> NoneIfNull<T>(this T value)
    {
        return When(value, value is not null);
    }
}
