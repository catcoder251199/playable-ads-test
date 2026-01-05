using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Pooling
{
    public class PoolManager : GenericMonoSingleton<PoolManager>
    {
        readonly Dictionary<Type, IPool> pools = new Dictionary<Type, IPool>();

        public IPool<T> GetOrCreatePool<T>(
            T prefab,
            int preload = 0,
            Transform parent = null)
            where T : PoolableMonoBehaviour
        {
            var type = typeof(T);

            if (!pools.TryGetValue(type, out var pool))
            {
                pool = new GenericGameObjectPool<T>(prefab, preload, parent);
                pools[type] = pool;
            }

            return (IPool<T>)pool;
        }

        public bool TryGetPool<T>(out IPool<T> pool)
            where T : PoolableMonoBehaviour
        {
            if (pools.TryGetValue(typeof(T), out var p))
            {
                pool = (IPool<T>)p;
                return true;
            }

            pool = null;
            return false;
        }
    }
}