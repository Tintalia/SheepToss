﻿using UnityEngine;
using System.Collections;
using System;

class DragonProjectile : Projectile
{
    public DragonProjectileType type { get; set; }
    public int Attack { get; set; }
    public float speed = 500;

    public void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(this.gameObject);
    }

    public override void Move()
    {
    }

    void Start()
    {
        rigidbody2D.velocity = transform.right * speed * Time.deltaTime;
    }
}
