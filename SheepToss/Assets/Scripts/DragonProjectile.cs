using UnityEngine;
using System.Collections;
using System;

class DragonProjectile : Projectile, IDamageCalculatable
{
    private int damage;
    private int speed;
    private DragonProjectileType dragonProjectileType;

    public DragonProjectile()
    {
        this.Speed = 10;
        CalculateDamage();
    }

    public int Damage
    {
        get
        {
            return this.damage;
        }
        set
        {
            Utilities.ValidateInt(value, "Damage");
            this.damage = value;
        }
    }

    public int Speed
    {
        get
        {
            return this.speed;
        }
        set
        {
            Utilities.ValidateInt(value, "Speed");
            this.speed = value;
        }
    }

    public DragonProjectileType DragonProjectileType
    {
        get
        {
            return this.dragonProjectileType;
        }
        set
        {
            Utilities.ValidateObject(value, "Dragon Projectile Type");
            this.dragonProjectileType = value;
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Sheppard>() != null)
        {
            Sheppard sheppardHit = other.gameObject.GetComponent<Sheppard>();
            sheppardHit.HP -= this.Damage;
        }
		
        Destroy(this.gameObject);
    }

    public override void Move()
    {
    }

    void Start()
    {
        rigidbody2D.velocity = transform.right * speed;
    }

    public void CalculateDamage()
    {
        switch (DragonProjectileType)
        {
            case DragonProjectileType.LightningBall:
                this.Damage = 50;
                break;
            case DragonProjectileType.Fire:
                this.Damage = 90;
                break;
            case DragonProjectileType.Water:
                this.Damage = 45;
                break;
            default:
                this.Damage = 30;
                break;
        }
    }
}
