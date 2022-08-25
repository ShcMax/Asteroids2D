using UnityEngine;

namespace ServiceLocator.Scripts
{
    public class ServiceLocatorExample : MonoBehaviour
    {
        [ContextMenu("Test ServiceLocator")]
        private void TestServiceLocator()
        {
            var service = new Service();
            ServiceLocator.SetService<IService>(service);

            // ...

            var resolve = ServiceLocator.Resolve<IService>();
            resolve.DoSomething();
        }

        [ContextMenu("Test ServiceLocator Alternative Service")]
        private void TestServiceLocatorAlternativeService()
        {
            ServiceLocator.SetService<IService>(new ServiceAlternative());

            var resolve = ServiceLocator.Resolve<IService>();
            resolve.DoSomething();
        }

        [ContextMenu("Test ServiceLocatorMonoBehaviour")]
        private void TestServiceLocatorMonoBehaviour()
        {
            var spriteRenderer = ServiceLocatorMonoBehaviour.GetService<SpriteRenderer>();
            // Do something with the service/component
            spriteRenderer.color = Color.blue;
        }
    }
}