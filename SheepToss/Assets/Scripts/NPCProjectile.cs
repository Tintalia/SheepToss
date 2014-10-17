using UnityEngine;
using System.Collections;
using System;

class NPCProjectile : Projectile
{
    public NPCProjectileType type { get; set; }
    public Transform Target;
    public int Damage { get; set; }
    public float speed = 10;
    private float distanceTravelled;
    static int arrowsInstantiated = 0;
    public float PlayerInitialPosition;
    public float decreaseAngle = 0.8f;

    public void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(this.gameObject);
    }

    public override void Move()
    {
    }

    void Update()
    {
        this.distanceTravelled += 0.1f;
        if (this.distanceTravelled < 2.7)
        {
            if (this.rigidbody2D.position != null)
            {
                if (this.rigidbody2D.position.y < PlayerInitialPosition - 1f)
                {
                    this.rigidbody2D.position += new Vector2(0, 0.1f);
                }
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

    void Start()
    {
        this.PlayerInitialPosition = UnityEngine.GameObject.FindGameObjectWithTag("Player").rigidbody2D.position.y;
        //this.decreaseAngle = 1.1f - this.PlayerInitialPosition;
        rigidbody2D.velocity = transform.right * speed;
        distanceTravelled = 0;
        arrowsInstantiated++;
        this.rigidbody2D.rotation = 30f;

        this.rigidbody2D.rotation += (UnityEngine.GameObject.FindGameObjectWithTag("Player").rigidbody2D.position.y - 0.97f) * 9;

        this.Damage = 40;
    }
}