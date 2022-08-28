using UnityEngine;

namespace Builder.Scripts
{
    public static class GameObjectExtensions
    {
        public static GameObject SetName(this GameObject gameObject, string name)
        {
            gameObject.name = name;
            return gameObject;
        }

        public static GameObject AddRigidbody2D(this GameObject gameObject, float mass, float gravity)
        {
            var rigidbody2D = gameObject.GetOrAddComponent<Rigidbody2D>();
            rigidbody2D.mass = mass;
            rigidbody2D.gravityScale = gravity;
            return gameObject;
        }

        public static GameObject AddBoxCollider2D(this GameObject gameObject)
        {
            gameObject.GetOrAddComponent<BoxCollider2D>();
            return gameObject;
        }

        public static GameObject AddSprite(this GameObject gameObject, Sprite sprite)
        {
            var spriteRenderer = gameObject.GetOrAddComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprite;
            return gameObject;
        }

        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            var result = gameObject.GetComponent<T>();
            if (!result)
            {
                result = gameObject.AddComponent<T>();
            }

            return result;
        }

        // Another chain example
        public static GameObject GetOrAddComponentChained<T>(this GameObject gameObject) where T : Component
        {
            var result = gameObject.GetComponent<T>();
            if (!result)
            {
                gameObject.AddComponent<T>();
            }

            return gameObject;
        }
    }
}