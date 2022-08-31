using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids.Object_Pool;

namespace Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        [SerializeField]
        private float max, current;
        [SerializeField]
        private int capacityPool;
        
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
        }
    }
}