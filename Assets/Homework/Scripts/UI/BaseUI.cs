using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal abstract class BaseUI : MonoBehaviour
{
    public abstract void Execute();
    public abstract void Cancel();
    //public abstract void Repeat();
}
