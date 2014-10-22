using UnityEngine;
using System;

public class BossProjectile : Projectile, IDamageCalculatable
{
    private int damage;
    private int speed;
    private DragonProjectileType dragonProjectileType;

    public BossProjectile()
    {
        this.Speed = 10;
        this.dragonProjectileType = DragonProjectileType.LightningBall;

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

    public override void Move()
    {
    }

    void Start()
    {
        rigidbody2D.velocity = -transform.right * speed;
    }

    public void OnCollisionEnter2D()
    {
        Destroy(this.gameObject);
    }

    public void CalculateDamage()
    {
        switch (this.DragonProjectileType)
        {
            case DragonProjectileType.LightningBall:
                this.Damage = 50;
                break;
            case DragonProjectileType.Fire:
                this.Damage = 45;
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
