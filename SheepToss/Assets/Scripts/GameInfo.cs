using System;
using UnityEngine;

class GameInfo : GameObject
{
    public static UnityEngine.GameObject dragon = UnityEngine.GameObject.FindGameObjectWithTag("Player");
    public static NightFury nightFury = dragon.GetComponent<NightFury>();
    public static SheppardSpawn sheppardSpawn = UnityEngine.GameObject.FindGameObjectWithTag("SheppardSpawn")
        .GetComponent<SheppardSpawn>();
    public static Sheppard sheppard = UnityEngine.GameObject.FindGameObjectWithTag("Sheppard")
        .GetComponent<Sheppard>();
}