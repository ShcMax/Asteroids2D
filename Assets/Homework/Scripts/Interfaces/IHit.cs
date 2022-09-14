using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Asteroids
{
    public interface IHit
    {
        event Action<float> OnHitChange;
        void Hit(float damage, string s);      
    }
}