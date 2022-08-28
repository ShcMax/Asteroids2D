using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{


    internal sealed class Example : MonoBehaviour
    {
        [SerializeField]
        private Sprite _sprite;        

        private void Start()
        {
            
        }

        public void Build(Sprite _sprite, Transform transform)
        {
            new GameObject().SetName("Enemy").SetTransform(transform).AddBoxCollider2D().AddRigidbody2D(1f, 1f).AddSprite(_sprite).AddForce(20f);
        }
    }
}