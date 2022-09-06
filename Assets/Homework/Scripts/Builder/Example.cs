using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    internal sealed class Example : MonoBehaviour
    {
        [SerializeField]
        private Sprite _sprite;
           

        public void Build(Sprite _sprite, Transform transform, Vector2 direction)
        {            
            new GameObject().SetName("Bullet").SetTransform(transform).AddBoxCollider2D().AddRigidbody2D(1f, 0f).AddSprite(_sprite).AddForce(0.1f, direction);
        }
    }
}