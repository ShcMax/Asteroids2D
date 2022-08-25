using UnityEngine;

namespace Singleton.Scripts
{
    public class SingletonMonoBehaviourAdvanced<T> : MonoBehaviour where T : Component
    {
        private static T _instance;

        private static readonly object _lock = new object();

        public static T Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance != null)
                    {
                        return _instance;
                    }

                    var instances = FindObjectsOfType<T>();

                    if (instances == null || instances.Length == 0)
                    {
                        // var go = new GameObject(typeof(T).Name, typeof(T));
                        var go = new GameObject(typeof(T).Name);
                        _instance = go.AddComponent<T>();
                        DontDestroyOnLoad(_instance.gameObject);
                    }
                    else /* (instances != null && instances.Length > 0) */
                    {
                        _instance = instances[0];
                        DontDestroyOnLoad(_instance.gameObject);

                        for (int i = 1; i < instances.Length; i++)
                        {
                            T extraInstance = instances[i];
                            Destroy(extraInstance.gameObject);
                        }
                    }

                    return _instance;
                }
            }
        }
    }
}