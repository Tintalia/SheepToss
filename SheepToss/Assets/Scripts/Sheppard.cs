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
        if (this.HP < 1)
        {
            Destroy(this.gameObject);
            if (UnityEngine.GameObject.FindGameObjectWithTag("Player") != null)
            {
                UnityEngine.GameObject.FindGameObjectWithTag("Player").GetComponent<NightFury>().Exp += 100;
            }
        }
        if (Time.time > nextFire)
        {
            if (UnityEngine.GameObject.FindGameObjectWithTag("Player").gameObject != null)
            {
                if (UnityEngine.GameObject.FindGameObjectWithTag("Player").gameObject.rigidbody2D.position.y - 4.2f <= this.rigidbody2D.position.y)
                {
                    nextFire = Time.time + rateOfFire;
                    Instantiate(arrow, arrowSpawn.position, arrowSpawn.rotation);
                }
            }
        }
    }

    void Start()
    {
        this.HP = 100;
    }
}