using UnityEngine;
using System.Collections;
using System;

public abstract class Sheep : Item, ICollectable, IMovable
{
    private int coins;
    private float speed;

    public Sheep()
    {
        this.Speed = 20;
    }

    public int Coins
    {
        get
        {
            return this.coins;
        }
        set
        {
            Utilities.ValidateInt(value, "Coins");
            this.coins = value;
        }
    }

    public float Speed
    {
        get
        {
            return this.speed;
        }
        set
        {
            Utilities.ValidateFloat(value, "Speed");
            this.speed = value;
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(this.gameObject);
    }

    public void Start()
    {
        this.gameObject.rigidbody2D.velocity = -transform.right * speed;
    }

    public void Update()
    {
        this.Move();
    }

    public void Move()
    {
        this.gameObject.rigidbody2D.position += new Vector2(0, 0.04f);

        if (this.gameObject.rigidbody2D.position.x < -16)
        {
            this.gameObject.rigidbody2D.gravityScale = 0.5f;
        }
    }
}