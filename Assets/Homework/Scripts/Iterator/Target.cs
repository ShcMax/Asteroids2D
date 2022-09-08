using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Iterator
{



    [Flags]
    internal enum Target
    {
        None = 0,
        Unit = 1,
        Autocast = 2,
        Passive = 4,
    }
}