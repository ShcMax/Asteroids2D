using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public static partial class BuilderExtensions
    {
        public static GameObject SetName (this GameObject gameObject, string name)
        {
            gameObject.name = name;
            return gameObject;
        }

        public static GameObject SetTransform (this GameObject gameObject, Transform transform)
        {
            gameObject.transform.position = transform.position;
            return gameObject;
        }

        public static GameObject AddRigidbody2D(this GameObject gameObject, float mass, float gravity)
        {
            var component = gameObject.GetOrAddComponent<Rigidbody2D>();
            component.mass = mass;
            component.gravityScale = gravity;            
            return gameObject;
        } 

        public static GameObject AddForce(this GameObject gameObject, float force, Vector2 _direction)
        {
            var component = gameObject.GetOrAddComponent<Rigidbody2D>();
            component.AddForce(_direction * force, ForceMode2D.Impulse);           
            return gameObject;
        }

        public static GameObject AddBoxCollider2D(this GameObject gameObject)
        {
            gameObject.GetOrAddComponent<BoxCollider2D>();
            return gameObject;
        }

        public static GameObject AddSprite(this GameObject gameObject, Sprite sprite)
        {
            var component = gameObject.GetOrAddComponent<SpriteRenderer>();
            component.sprite = sprite;
            return gameObject;
        }

        private static T GetOrAddComponent<T> (this GameObject gameObject) where T: Component
        {
            var result = gameObject.GetComponent<T>();
            if (!result)
            {
                result = gameObject.AddComponent<T>();
            }
            return result;
        }
    }

    
}
