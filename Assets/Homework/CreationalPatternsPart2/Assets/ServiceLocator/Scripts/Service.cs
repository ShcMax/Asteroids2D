using UnityEngine;

namespace ServiceLocator.Scripts
{
    public class Service : IService
    {
        public void DoSomething()
        {
            Debug.Log("Service.DoSomething: ");
        }
    }
}