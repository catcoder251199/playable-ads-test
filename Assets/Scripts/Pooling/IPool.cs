namespace DefaultNamespace.Pooling
{
    public interface IPool
    {
        
    }
    
    public interface IPool<T> : IPool where T : PoolableMonoBehaviour
    {
        T Spawn();
        void Despawn(T obj);
    }
}