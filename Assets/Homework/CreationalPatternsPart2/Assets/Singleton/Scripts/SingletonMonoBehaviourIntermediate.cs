using UnityEngine;

namespace Singleton.Scripts
{
    public class SingletonMonoBehaviourIntermediate<T> : MonoBehaviour where T : Component
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (!_instance)
                {
                    var singleton = new GameObject($"SingletonMonoBehaviourIntermediate<{typeof(T)}>");
                    DontDestroyOnLoad(singleton);

                    var singletonMonoBehaviour = singleton.AddComponent<T>();
                    _instance = singletonMonoBehaviour;
                }

                return _instance;
            }

            private set { _instance = value; }
        }

        public virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}