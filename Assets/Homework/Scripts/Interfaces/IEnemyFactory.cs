using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{

    public interface IEnemyFactory
    {
        Enemy Create(Health hp);
    }

}
