using System;
using System.Collections.Generic;

public static class ServiceLocator
{
    static readonly Dictionary<Type, object> _services =
        new Dictionary<Type, object>();

    public static void Register<T>(T service)
        where T : class
    {
        var type = typeof(T);
        _services[type] = service;
    }

    public static T GetService<T>()
        where T : class
    {
        var type = typeof(T);
        if (_services.TryGetValue(type, out var service))
            return service as T;

        throw new Exception($"Service {type.Name} not registered.");
    }

    public static bool TryGetService<T>(out T service)
        where T : class
    {
        if (_services.TryGetValue(typeof(T), out var obj))
        {
            service = obj as T;
            return true;
        }

        service = null;
        return false;
    }

    public static void Clear()
    {
        _services.Clear();
    }
}