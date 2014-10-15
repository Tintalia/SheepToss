using UnityEngine;
using System.Collections;
using System;

abstract class Sheep : Item, ICollectable
{
    public int coins; // The number life points it adds to the dragon after being collected
    public float speed = 20;

    public void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(this.gameObject);
    }

    void Start()
    {
        rigidbody2D.velocity = -transform.right * speed;
    }

    void Update()
    {
        rigidbody2D.position += new Vector2(0,0.04f);
        if (rigidbody2D.position.x < -16)
        {
            rigidbody2D.gravityScale = 0.5f;
        }
    }
}