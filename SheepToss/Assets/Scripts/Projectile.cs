using UnityEngine;
using System.Collections;
using System;

abstract class Projectile : Item, IMovable
{
    public abstract void Move();
}
