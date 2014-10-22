using UnityEngine;
using System.Collections;
using System;

public abstract class Projectile : Item, IMovable
{
    public abstract void Move();
}
