using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class Boss : NonPlayerCharacter, IMovable
{
    #region Private Members
    private float nextFire;
    private readonly int maxHP = 1000;
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
            Utilities.ValidateInt(value, "HP");
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
        if (UnityEngine.GameObject.FindGameObjectWithTag("Player")!=null)
        {
            if ((int)this.gameObject.rigidbody2D.position.y == (int)(UnityEngine.GameObject.FindGameObjectWithTag("Player").gameObject.rigidbody2D.position.y - 1.5f))
            {
            }
            else if (this.gameObject.rigidbody2D.position.y < UnityEngine.GameObject.FindGameObjectWithTag("Player").gameObject.rigidbody2D.position.y - 1.5f)
            {
                this.gameObject.rigidbody2D.position += new Vector2(0, 0.1f);
            }
            else
            {
                this.gameObject.rigidbody2D.position -= new Vector2(0, 0.1f);
            }
        }
        //float xClamp = Mathf.Clamp(this.gameObject.rigidbody2D.position.x, this.Boundary.xMin, this.Boundary.xMax);
        //float yClamp = Mathf.Clamp(this.gameObject.rigidbody2D.position.y, this.Boundary.yMin, this.Boundary.yMax);

        //this.gameObject.rigidbody2D.position = new Vector3(xClamp, yClamp, 0.0f);
    }

    public void Start()
    {
        DefineBoundaries();
    }

    private void Fire()
    {
        if (Time.time > this.NextFire)
        {
            this.NextFire = Time.time + this.RateOfFire;
            Instantiate(this.Shot, this.ShotSpawn.position, this.ShotSpawn.rotation);
        }
    }

    public void Update()
    {
        this.UpdateHP();
        this.Move();
        this.Fire();
    }

    private void UpdateHP()
    {
        this.HP -= 1;

        if (this.HP > this.maxHP)
        {
            this.HP = this.maxHP;
        }

        if (this.HP < 1)
        {
            Destroy(this.gameObject);// here goes the falling dragon animation
            Time.timeScale = 0.0f;
        }
    }

    private void DefineBoundaries()
    {
        this.Boundary.xMin = -28;
        this.Boundary.xMax = -12;
        this.Boundary.yMin = -3;
        this.Boundary.yMax = 5;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
    }
}