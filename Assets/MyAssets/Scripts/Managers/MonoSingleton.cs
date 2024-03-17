using UnityEngine;

public abstract class MonoSingleton<T> : CustomManager where T : MonoSingleton<T>
{
    private static volatile T _instance = null;

    private static readonly object _lockOnject = new object();

    public static T Instance
    {
        get
        {
            if (_instance == null)
                lock (_lockOnject)
                    if (_instance == null)
                        _instance = FindObjectOfType(typeof(T)) as T;

            return _instance;
        }
    }
}
