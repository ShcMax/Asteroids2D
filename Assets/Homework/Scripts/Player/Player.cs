using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Builder.Scripts;

namespace Asteroids
{
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _force;
        [SerializeField] private float _moveForce;
        
        private Example example;
        [SerializeField] private Sprite _sprite;

        private Camera _camera;
        private Ship _ship;
        
        private Rigidbody2D _playerRigidbody;        

        private void Awake()
        {
            _camera = Camera.main;
            _playerRigidbody = GetComponent<Rigidbody2D>();           
            example = new Example();
        }
        private void Start()
        {
            var moveTransform = new AccelerationMove(transform, _speed, _acceleration);
            var rotation = new RotationShip(transform);
            _ship = new Ship(moveTransform, rotation);  
        }

        private void Update()
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
            _ship.Rotation(direction);

            _ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _ship.AddAcceleration();                
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _ship.RemoveAcceleration();
            }

            if (Input.GetButtonDown("Fire1"))
            {
                example.Build(_sprite, _barrel);
                
                //var temAmmunition = Instantiate(_bullet, _barrel.position, _barrel.rotation);
                //temAmmunition.AddForce(_barrel.up * _force);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if(_hp <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                _hp--;
            }
        }        
    }
}
