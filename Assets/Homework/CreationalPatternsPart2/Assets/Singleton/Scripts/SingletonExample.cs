using System.Collections.Generic;
using UnityEngine;

namespace Singleton.Scripts
{
    public class SingletonExample : MonoBehaviour
    {
        [ContextMenu("Test Singleton Services")]
        private void TestSingletonServices()
        {
            SingletonServices.Instance.SayHello();
        }

        [ContextMenu("Test Singleton Services 2")]
        private void TestSingletonServices2()
        {
            var colliders = SingletonServices.Instance.GetObjectsInRadius(transform.position, 10);
            Debug.Log("SingletonExample.TestSingletonServices2: colliderInRadius = " + ((List<Collider>)colliders).Count);

            foreach (var colliderInRadius in colliders)
            {
                Debug.Log("SingletonExample.TestSingletonServices2: colliderInRadius = " + colliderInRadius.name);
            }
        }

        [ContextMenu("Test Singleton MB Basic")]
        private void TestSingletonBasic()
        {
            SingletonMonoBehaviourBasic.Instance.SayHello();
        }


        [ContextMenu("Test Singleton MB Intermediate")]
        private void TestSingletonIntermediate()
        {
            SingletonMonoBehaviourIntermediateImpl.Instance.SayHello();
        }
        
        
        [ContextMenu("Test Singleton MB Advanced")]
        private void TestSingletonAdvanced()
        {
            SingletonMonoBehaviourAdvancedImpl.Instance.SayHello();
        }
    }
}