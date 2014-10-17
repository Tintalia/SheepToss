using UnityEngine;
using System.Collections;
using System;

class NPCProjectile : Projectile
{
    #region Private Members
    private int damage;
    private int speed;
    private DragonProjectileType npcProjectileType;

    private UnityEngine.GameObject target;
    private float distanceTravelled;
    private static int arrowsInstantiated = 0;
    private float targetInitialPosition;
    private float decreaseAngle;
    #endregion

    public NPCProjectile()
    {
        this.Speed = 10;
        this.Damage = 50;
        this.DecreaseAngle = 0.8f;
    }

    #region Public Members
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

    public DragonProjectileType NPCProjectileType
    {
        get
        {
            return this.npcProjectileType;
        }
        set
        {
            Utilities.ValidateObject(value, "Dragon Projectile Type");
            this.npcProjectileType = value;
        }
    }

    public UnityEngine.GameObject Target
    {
        get
        {
            return this.target;
        }
        set
        {
            Utilities.ValidateObject(value, "Target");
            this.target = value;
        }
    }

    public float DistanceTravelled
    {
        get
        {
            return this.distanceTravelled;
        }
        set
        {
            Utilities.ValidateFloat(value, "Distance travelled");
            this.distanceTravelled = value;
        }
    }

    public int ArrowsInstantiated
    {
        get
        {
            return arrowsInstantiated;
        }
        set
        {
            Utilities.ValidateInt(value, "Arrows Instantiated");
            arrowsInstantiated = value;
        }
    }

    public float TargetInitialPosition
    {
        get
        {
            return this.targetInitialPosition;
        }
        set
        {
            this.targetInitialPosition = value;
        }
    }

    public float DecreaseAngle
    {
        get
        {
            return this.decreaseAngle;
        }
        set
        {
            Utilities.ValidateFloat(value, "Decrease angle");
            this.decreaseAngle = value;
        }
    }
    #endregion

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
        this.distanceTravelled += 0.1f;
        if (this.distanceTravelled < 2.7)
        {
            if (this.rigidbody2D.position.y < TargetInitialPosition - 1f)
            {
                this.rigidbody2D.position += new Vector2(0, 0.1f);
            }

            if (this.distanceTravelled < 2.3)
            {
                this.rigidbody2D.rotation -= decreaseAngle;
            }
        }
        else if (distanceTravelled < 2.9)
        {
            this.rigidbody2D.gravityScale = 0.5f;
            this.rigidbody2D.rotation -= 0.5f;
        }
        else
        {
            this.rigidbody2D.gravityScale = 1;
            this.rigidbody2D.rotation -= 0.5f;
        }
    }

    void Update()
    {
        this.Move();
    }

    void Start()
    {
        this.Target = UnityEngine.GameObject.FindGameObjectWithTag("Player");

        this.TargetInitialPosition = this.Target.rigidbody2D.position.y;
        this.gameObject.rigidbody2D.velocity = transform.right * speed;
        this.rigidbody2D.rotation = 30f;
        this.rigidbody2D.rotation += (this.Target.rigidbody2D.position.y - 0.97f) * 9;

    }
}