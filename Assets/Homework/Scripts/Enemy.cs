using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Asteroids.Object_Pool;

namespace Asteroids
{
    internal abstract class Enemy : MonoBehaviour, IHit
    {
        public event Action<float> OnHitChange = delegate { };


        public static IEnemyFactory Factory;
        private Transform _rotPool;
        private Health _health;

        public Health Health
        {
            get
            {
                if(_health.Current <= 0)
                {
                    ReturnToPool();
                }
                return _health;
            }

            protected set => _health = value;
        }

        public Transform RotPool
        {
            get
            {
                if (_rotPool == null)
                {
                    var find = GameObject.Find(NameManager.POOL_AMMUNITION);
                    _rotPool = find == null ? null : find.transform;
                }
                return _rotPool;
            }
        }
        public void Hit(float damage)
        {
            OnHitChange?.Invoke(damage);
            Debug.Log("Enemy destroy" + "damage = "+ damage);
        }

        public static Asteroid CreateAsteroidEnemy(Health hp)
        {
            var enemy = Instantiate(Resources.Load<Asteroid>("Enemy/Asteroid"));
            enemy.Health = hp;
            return enemy;
        }

        public void ActiveEnemy(Vector3 position, Quaternion rotation)
        {
            transform.localPosition = position;
            transform.localRotation = rotation;
            gameObject.SetActive(true);
            transform.SetParent(null);
        }

        protected void ReturnToPool()
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            gameObject.SetActive(false);
            transform.SetParent(RotPool);

            if (!RotPool)
            {
                Destroy(gameObject);
            }
        }

        public void DependencyInjectHealth(Health hp)
        {
            Health = hp;
        }        
    }
}