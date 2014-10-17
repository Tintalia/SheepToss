using UnityEngine;
using System.Collections;
using System;

class Package : Item, ICollectable
{
    private int lifePoints;

    public Package()
    {
        this.LifePoints = 100;
    }

    public int LifePoints
    {
        get
        {
            return this.lifePoints;
        }
        set
        {
            Utilities.ValidateInt(value, "Life Points");
            this.lifePoints = value;
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(this.gameObject);
    }

    void Start()
    {
        //rigidbody2D.velocity = -transform.up * speed;
    }

    void Update()
    {
    }
}