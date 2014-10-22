using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class Boss : NonPlayerCharacter, IMovable, IDestructable
{
    #region Private Members
    private float nextFire;
    private readonly int maxHP = 200;
    private int attack;
    private int speed;
    private int hp;
    private float rateOfFire;
    #endregion

    public Boss()
    {
        this.Speed = 10;
        this.HP = this.maxHP;
        this.RateOfFire = 0.75f;
    }

    #region Public Members
    public int Attack
    {
        get
        {
            return this.attack;
        }
        set
        {
            Utilities.ValidateInt(value, "Attack");
            this.attack = value;
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

    public int HP
    {
        get
        {
            return this.hp;
        }
        set
        {
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

    public float NextFire
    {
        get
        {
            return this.nextFire;
        }
        set
        {
            Utilities.ValidateFloat(value, "Next Fire");
            this.nextFire = value;
        }
    }

    public Boundary Boundary;
    public Transform Shot;
    public Transform ShotSpawn;
    #endregion

    public override void Move()
    {
        if (UnityEngine.GameObject.FindGameObjectWithTag("Player") != null)
        {

            if (this.gameObject.rigidbody2D.position.y - 0.5f < (UnityEngine.GameObject.FindGameObjectWithTag("Player").gameObject.rigidbody2D.position.y)
                && (this.gameObject.rigidbody2D.position.y + 0.5f > (UnityEngine.GameObject.FindGameObjectWithTag("Player").gameObject.rigidbody2D.position.y)))
            {
            }
            else if (this.gameObject.rigidbody2D.position.y < UnityEngine.GameObject.FindGameObjectWithTag("Player").gameObject.rigidbody2D.position.y)
            {
                this.gameObject.rigidbody2D.position += new Vector2(0, 0.1f);
            }
            else
            {
                this.gameObject.rigidbody2D.position -= new Vector2(0, 0.1f);
            }
        }
    }

    public void UpdateHP()
    {
        if (this.HP < 1)
        {
            this.Destroy();
            UnityEngine.GameObject.FindGameObjectWithTag("Player").GetComponent<NightFury>().HP +=
                UnityEngine.GameObject.FindGameObjectWithTag("Player").GetComponent<NightFury>().MaxHP;
        }
    }

    private void Fire()
    {
        if (Time.time > this.NextFire)
        {
            this.NextFire = Time.time + this.RateOfFire;
            Instantiate(this.Shot, new Vector2(this.ShotSpawn.position.x, this.ShotSpawn.position.y - 1), this.ShotSpawn.rotation);
        }
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }

    public void Update()
    {
        this.Move();
        this.Fire();
        this.UpdateHP();
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<DragonProjectile>() != null)
        {
            DragonProjectile encounteredProjectile = other.gameObject.GetComponent<DragonProjectile>();
            this.HP -= encounteredProjectile.Damage;
        }
    }
}