using UnityEngine;
using System.Collections;
using System;

class Sheppard : NonPlayerCharacter, ILivable
{
    public float HP { get; set; }
    public Transform arrow;
    public Transform arrowSpawn;
    public float rateOfFire;
    private float nextFire;
    public override void Move()
    {
       
    }
    public void Update()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + rateOfFire;
            Instantiate(arrow, arrowSpawn.position, arrowSpawn.rotation);
        }
    }
}