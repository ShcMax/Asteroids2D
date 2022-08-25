using UnityEngine;

namespace ServiceLocator.Scripts
{
    public class ServiceAlternative : IService
    {
        public void DoSomething()
        {
            Debug.Log("ServiceAlternative.DoSomething: ");
        }
    }
}