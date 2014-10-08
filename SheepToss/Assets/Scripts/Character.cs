using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour
{
    public int health;
    protected abstract void Move();
}
