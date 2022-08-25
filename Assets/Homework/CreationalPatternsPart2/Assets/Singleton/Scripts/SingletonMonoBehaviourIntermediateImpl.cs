using UnityEngine;

namespace Singleton.Scripts
{
    public class SingletonMonoBehaviourIntermediateImpl : SingletonMonoBehaviourIntermediate<SingletonMonoBehaviourIntermediateImpl>
    {
        public void SayHello()
        {
            Debug.Log("SingletonMonoBehaviourIntermediateImpl.SayHello: ");
        }
    }
}