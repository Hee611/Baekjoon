// Objects
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatBase : MonoBehaviour
{
    protected bool _isDead;

    protected abstract void InitBase();
    protected abstract bool OnHitting();
}