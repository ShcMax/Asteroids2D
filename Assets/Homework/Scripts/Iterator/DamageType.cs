using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Iterator
{


    [Flags]
    internal enum DamageType
    {
        None = 0,
        Magical = 1,
        Pure = 2,
    }
}