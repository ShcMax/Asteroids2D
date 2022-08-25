using UnityEngine;

namespace Singleton.Scripts
{
    public class SingletonMonoBehaviourAdvancedImpl : SingletonMonoBehaviourAdvanced<SingletonMonoBehaviourAdvancedImpl>
    {
        public void SayHello()
        {
            Debug.Log("SingletonMonoBehaviourAdvancedImpl.SayHello: ");
        }
    }
}