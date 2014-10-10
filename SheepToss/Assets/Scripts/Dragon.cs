using UnityEngine;
using System.Collections;

public abstract class Dragon : Character, ILivable, IMovable
{
    public int Attack { get; set; } //Projectile attack value + bonuses (if there are any)
    public int Speed { get; set; }
    public int Armor { get; set; }
    public int Firepower { get; set; }
    public int ShotLimit { get; set; }
    public int Venom { get; set; }
    public int JawStrength { get; set; }
    public int Stealth { get; set; }
    public int HP { get; set; }

    public override void Move()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        rigidbody2D.velocity = movement * speed;

        rigidbody2D.position = new Vector3
        (
            Mathf.Clamp(rigidbody2D.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(rigidbody2D.position.y, boundary.yMin, boundary.yMax),
            0.0f
        );
    }

    public float speed = 10;
    public Boundary boundary;

    void Start()
    {
        this.HP = 600;
    }

    void FixedUpdate()
    {
        this.Move();
        this.UpdateHP();
    }

    private void UpdateHP()
    {
        if (this.HP >= 3)
        {
            this.HP -= 3;
        }
        else
        {
            Destroy(gameObject);//here goes the falling dragon animation
            Time.timeScale = 0.0f;
        }
        Debug.Log(this.HP);
    }
}

[System.Serializable]
public class Boundary
{
    public float xMin = -28f, xMax = -13f, yMin = -1f, yMax = 5f;
}
