using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Iterator
{
    internal interface IAbility
    {
        string Name { get; }
        int Damage { get; }
        Target Target { get; }
        DamageType DamageType { get; }

    }
}