namespace EasyLife.AutoInject.Attributes;

public enum ServiceLifetime
{
    Singleton = 1,
    Transient = 2,
    Scoped = 4,
}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class AutoInjectAttribute(Type baseType = null, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
    : System.Attribute
{
    public ServiceLifetime ServiceLifetime { get; set; } = serviceLifetime;

    public Type BaseType { get; set; } = baseType;
}


#if NET7_0_OR_GREATER

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class AutoInjectAttribute<T>(ServiceLifetime serviceLifetime = ServiceLifetime.Scoped) : AutoInjectAttribute(typeof(T), serviceLifetime)
{
}

#endif

#if NET8_0_OR_GREATER

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class AutoInjectKeyedAttribute<T>(string key, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped) : AutoInjectAttribute(typeof(T), serviceLifetime)
{
    public string Key { get; set; } = key ?? throw new ArgumentNullException(nameof(key));
}

#endif