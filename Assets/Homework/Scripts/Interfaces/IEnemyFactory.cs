using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal interface IEnemyFactory
    {
        Enemy Create(Health hp);
    }
}
