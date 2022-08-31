using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids.Object_Pool;


namespace Asteroids
{


    internal sealed class GameService
    {
        public void Start (float max, float current, int capacityPool)
        {
            var player = CreatePlayer(max, current);
            var enemyPool = CreateEnemy(capacityPool);
        }

        private Health CreatePlayer(float max, float current)
        {
            return new Health(max, current);
        }
       
        private EnemyPool CreateEnemy(int capacityPool)
        {
            return new EnemyPool(capacityPool);
        }
    }

    
}