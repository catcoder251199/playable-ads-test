using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.Pooling
{
    public class GenericGameObjectPool<T> : IPool<T> where T : PoolableMonoBehaviour
    {
        readonly Stack<T> pool = new Stack<T>();
        readonly T prefab;
        readonly Transform parent;

        public GenericGameObjectPool(
            T prefab,
            int preload = 0,
            Transform parent = null)
        {
            this.prefab = prefab;
            this.parent = parent;

            for (int i = 0; i < preload; i++)
                pool.Push(Create());
        }

        private T Create()
        {
            var obj = Object.Instantiate(prefab, parent);
            obj.gameObject.SetActive(false);
            return obj;
        }

        public T Spawn()
        {
            var obj = pool.Count > 0 ? pool.Pop() : Create();
            obj.OnSpawn();
            return obj;
        }

        public void Despawn(T obj)
        {
            obj.OnDespawn();
            pool.Push(obj);
        }
    }
}