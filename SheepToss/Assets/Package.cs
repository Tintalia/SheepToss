using UnityEngine;
using System.Collections;
using System;

class Package : Item, ICollectable
{
    public int LifePoints { get; set; } // The number life points it adds to the dragon after being collected

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