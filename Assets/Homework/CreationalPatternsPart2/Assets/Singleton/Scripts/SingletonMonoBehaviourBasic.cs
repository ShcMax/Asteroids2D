using UnityEngine;

namespace Singleton.Scripts
{
    public class SingletonMonoBehaviourBasic : MonoBehaviour
    {
        private static SingletonMonoBehaviourBasic _instance;

        public static SingletonMonoBehaviourBasic Instance
        {
            get
            {
                if (!_instance)
                {
                    var singleton = new GameObject("SingletonMonoBehaviourBasic");
                    var singletonMonoBehaviour = singleton.AddComponent<SingletonMonoBehaviourBasic>();

                    _instance = singletonMonoBehaviour;
                }

                return _instance;
            }
        }

        private void Awake()
        {
            if (_instance)
            {
                Destroy(this);
                return;
            }

            _instance = this;

            // Optional
            // DontDestroyOnLoad(this);
        }

        private bool _isHappy;
        
        public void SayHello()
        {
            if (_isHappy)
            {
                Debug.Log("SingletonMonoBehaviourBasic.SayHello: ");
            }
            else
            {
                
            }

            _isHappy = !_isHappy;
        }
    }
}