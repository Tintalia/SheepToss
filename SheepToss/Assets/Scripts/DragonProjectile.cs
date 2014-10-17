using UnityEngine;
using System.Collections;
using System;

class DragonProjectile : Projectile
{
    public DragonProjectileType type { get; set; }
    public int Attack { get; set; }
    public float speed = 10;

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Sheppard>() != null)
        {
            other.gameObject.GetComponent<Sheppard>().HP -= this.Attack;
        }
        Destroy(this.gameObject);
    }

    public override void Move()
    {
    }

    void Start()
    {
        this.Attack = 50;
        rigidbody2D.velocity = transform.right * speed;
    }
}
