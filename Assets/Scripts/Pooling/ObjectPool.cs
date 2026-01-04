using System;
using System.Collections.Generic;

namespace DefaultNamespace.Pooling
{
    public class ObjectPool<T> where T : class
    {
        readonly Stack<T> _pool = new Stack<T>();
        readonly Func<T> _factory;
        readonly Action<T> _onGet;
        readonly Action<T> _onRelease;

        public int Count => _pool.Count;

        public ObjectPool(
            Func<T> factory,
            Action<T> onGet = null,
            Action<T> onRelease = null,
            int preload = 0)
        {
            _factory = factory;
            _onGet = onGet;
            _onRelease = onRelease;

            for (int i = 0; i < preload; i++)
                _pool.Push(_factory());
        }

        public T Get()
        {
            var obj = _pool.Count > 0
                ? _pool.Pop()
                : _factory();

            _onGet?.Invoke(obj);
            return obj;
        }

        public void Release(T obj)
        {
            _onRelease?.Invoke(obj);
            _pool.Push(obj);
        }
    }
}