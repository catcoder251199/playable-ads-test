using UnityEngine;

public abstract class GenericMonoSingleton<T> : MonoBehaviour
    where T : MonoBehaviour
{
    private static T _instance;
    private static bool _isShuttingDown;

    public static T Instance
    {
        get
        {
            if (_isShuttingDown)
                return null;

            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();

                if (_instance == null)
                {
                    var go = new GameObject(typeof(T).Name);
                    _instance = go.AddComponent<T>();
                }
            }
            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnApplicationQuit()
    {
        _isShuttingDown = true;
    }
}