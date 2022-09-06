using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Asteroids.Object_Pool;

namespace Asteroids
{
    internal sealed class GameStarter : MonoBehaviour
    {
        [SerializeField]
        private float max, current;
        [SerializeField]
        private int capacityPool;

        [SerializeField] private Text _text;
        [SerializeField] private InputField _inputField;


        
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

            _inputField.onValueChanged.AddListener(Interpret);

        }

        private void Interpret(string value)
        {
            if(Int64.TryParse(value, out var number))
            {
                _text.text = ToScores(number);
            }
            if (Double.TryParse(value, out var number1))
            {
                _text.text = ToScoresDouble(number1);
            }
        }

        private string ToScores(long number)
        {
            if (number < 0 || number > 20000000)
            {
                return "insert value betwheen 1 and 2000000";
            }            
            if (number >= 1000) return "1K" + ToScores(number - 1000);            
            if (number >= 30000) return "30K" + ToScores(number - 30000);
            if (number >= 2000000) return "2M" + ToScores(number - 2000000);

            return string.Empty;
        }

        private string ToScoresDouble(double number)
        {
            if (number < 0 || number > 20000000)
            {
                return "insert value betwheen 1 and 2000000";
            }            
            if (number < 1) return string.Empty;
            if (number >= 2100.00) return "2K" + ToScoresDouble(number - 2000);

            return string.Empty;
        }
    }
}