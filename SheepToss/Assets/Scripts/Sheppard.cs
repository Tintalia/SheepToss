using UnityEngine;
using System.Collections;
using System;

class Sheppard : NonPlayerCharacter, ILivable, IDestructable
{
    private float hp;
    private float rateOfFire;
    private float nextFire;
    private UnityEngine.GameObject target;

    public Sheppard()
    {
        this.HP = 100;
        this.RateOfFire = 0.4f;
    }

    public float HP
    {
        get
        {
            return this.hp;
        }
        set
        {
            Utilities.ValidateFloat(value, "HP");
            this.hp = value;
        }
    }

    public float RateOfFire
    {
        get
        {
            return this.rateOfFire;
        }
        set
        {
            Utilities.ValidateFloat(value, "Rate of fire");
            this.rateOfFire = value;
        }
    }

    public Transform arrow;
    public Transform arrowSpawn;

    public UnityEngine.GameObject Target
    {
        get
        {
            return this.target;
        }
        set
        {
            Utilities.ValidateObject(value, "Target");
            this.target = value;
        }
    }

    public void Start()
    {
        this.Target = UnityEngine.GameObject.FindGameObjectWithTag("Player");
    }

    public override void Move()
    {
    }

    private void UpdateHP()
    {
        if (this.HP < 1)
        {
            UnityEngine.GameObject.FindGameObjectWithTag("SheppardSpawn").GetComponent<SheppardSpawn>().NextSpawn
                = Time.time + UnityEngine.GameObject.FindGameObjectWithTag("SheppardSpawn").GetComponent<SheppardSpawn>().RateOfSpawn;
            this.Destroy();
            this.Target.GetComponent<NightFury>().HP += 100;
            this.Target.GetComponent<NightFury>().Exp += 100; // Added -----------------------------------------------
        }
    }

    private void ShootArrow()
    {
        if (Time.time > nextFire)
        {
            if (this.Target.gameObject != null)
            {
                if (this.Target.gameObject.rigidbody2D.position.y - 4.2f <= this.rigidbody2D.position.y)
                {
                    nextFire = Time.time + rateOfFire;
                    Instantiate(arrow, arrowSpawn.position, arrowSpawn.rotation);
                }
            }
        }
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }

    public void Update()
    {
        this.UpdateHP();
        this.ShootArrow();
    }
}