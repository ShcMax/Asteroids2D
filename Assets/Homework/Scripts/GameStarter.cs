using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        private void Start()
        {
            Enemy.CreateAsteroidEnemy(new Health(100, 100));

            IEnemyFactory factory = new AsteroidFactory();
            factory.Create(new Health(100, 100));

            Enemy.Factory = factory;
            Enemy.Factory.Create(new Health(100, 100));
        }
    }
}