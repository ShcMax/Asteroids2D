using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Singleton.Scripts
{
    public class SingletonServices
    {
        private static readonly Lazy<SingletonServices> _instance = new Lazy<SingletonServices>(() => new SingletonServices(), LazyThreadSafetyMode.ExecutionAndPublication);
        public static SingletonServices Instance => _instance.Value;

        private SingletonServices()
        {
        }

        public void SayHello()
        {
            Debug.Log("SingletonServices.SayHello: ");
        }

        public IEnumerable<Collider> GetObjectsInRadius(Vector3 position, float radius)
        {
            var objectsInRadius = new List<Collider>();

            // Find objects in radius

            return objectsInRadius;
        }


        #region Implementation of GetObjectsInRadius

        private readonly Collider[] _collidedObjects;
        private readonly List<Collider> _triggeredObjects;

        public IEnumerable<Collider> GetObjectsInRadiusImpl(Vector3 position, float radius, int layerMask = 0)
        {
            _triggeredObjects.Clear();
            Collider trigger;

            var collidersCount = Physics.OverlapSphereNonAlloc(position, radius, _collidedObjects, layerMask);
            for (int i = 0; i < collidersCount; i++)
            {
                trigger = _collidedObjects[i];

                if (trigger != null && !_triggeredObjects.Contains(trigger))
                {
                    _triggeredObjects.Add(trigger);
                }
            }

            return _triggeredObjects;
        }

        #endregion
    }
}