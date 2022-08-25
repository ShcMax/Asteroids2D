using System.Collections.Generic;
using UnityEngine;

namespace Prototype.Scripts
{
    public class MyCloneableObject : MonoBehaviour, IMyCloneable
    {
        private static int _cloneCount = 0;

        [SerializeField]
        private int _numLives;

        [SerializeField]
        private List<Object> _inventory;


        public IMyCloneable Clone()
        {
            _cloneCount += 1;

            var newObject = new GameObject($"{name} clone #{_cloneCount}");
            var myCloneableObject = newObject.AddComponent<MyCloneableObject>();

            if (gameObject.TryGetComponent<Rigidbody2D>(out var rigidbody2D))
            {
                var newRigidbody2D = newObject.AddComponent<Rigidbody2D>();
                newRigidbody2D.velocity = rigidbody2D.velocity;
                newRigidbody2D.angularVelocity = rigidbody2D.angularVelocity;
                // etc.
            }

            if (gameObject.TryGetComponent<BoxCollider2D>(out var boxCollider2D))
            {
                var newBoxCollider2D = newObject.AddComponent<BoxCollider2D>();
                newBoxCollider2D.size = boxCollider2D.size;
                // etc.
            }

            if (gameObject.TryGetComponent<SpriteRenderer>(out var spriteRenderer))
            {
                var newSpriteRenderer = newObject.AddComponent<SpriteRenderer>();
                newSpriteRenderer.sprite = spriteRenderer.sprite;
                // etc.
            }

            myCloneableObject._numLives = _numLives;

            myCloneableObject._inventory = new List<Object>();
            foreach (var inventoryItem in _inventory)
            {
                myCloneableObject._inventory.Add(inventoryItem);
            }

            // Just for test purposes
            newObject.transform.position = transform.position + Vector3.right * _cloneCount;

            return myCloneableObject;
        }
    }
}