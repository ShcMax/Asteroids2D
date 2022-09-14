using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Asteroids.Object_Pool;
using Player.Modifier;

namespace Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        [SerializeField]
        private float max, current;
        [SerializeField]
        private int capacityPool;

        public Enemy Enemy;
        public float Damage;
        private Camera _mainCamera;
        private float _dedicateDistance = 20.0f;

        [SerializeField]
        Text text;        

        private void Start()
        {
            EnemyPool enemyPool = new EnemyPool(5);
            var enemy = enemyPool.GetEnemy("Asteroid");
            enemy.transform.position = Vector3.one;
            enemy.gameObject.SetActive(true);


            Enemy.CreateAsteroidEnemy(new Health(100, 100));
            IEnemyFactory factory = new AsteroidFactory();
            factory.Create(new Health(100, 100));
            Enemy.Factory = factory;
            Enemy.Factory.Create(new Health(100, 100));


            var gameService = new GameService();
            gameService.Start(max, current, capacityPool);


            var player = new TestPlayer("Player", 1, 1);

            var root = new PlayerModifier(player);
            root.Add(new AddAttackModifier(player, 5));
            root.Add(new AddAttackModifier(player, 10));
            root.Add(new AddDefenseModifier(player, 100));
            root.Handle();

            _mainCamera = Camera.main;
            var listenerHitShowDamage = new ListenerHitShowDamage();
            listenerHitShowDamage.Add(Enemy);
            
            Enemy.Hit(_dedicateDistance, text);
        }        
    }
}