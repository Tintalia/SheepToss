using UnityEngine;
using System.Collections;

public abstract class Character : GameObject, IMovable
{
    public abstract void Move();
}
