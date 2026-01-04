using UnityEngine;

namespace DefaultNamespace.Pooling
{
    public abstract class PoolableMonoBehaviour : MonoBehaviour, IPoolable
    {
        public virtual void OnSpawn()
        {
            gameObject.SetActive(true);
        }

        public virtual void OnDespawn()
        {
            gameObject.SetActive(false);
        }
    }
}