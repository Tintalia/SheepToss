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

    //public void Update()
    //{
    //    Move();
    //}
    public override void Move()
    {
        //    var horz = Input.GetAxis("Horizontal");
        //    var vert = Input.GetAxis("Vertical");
        //    var futurePosition = transform.position + (transform.right * horz + transform.up * vert) * 10 * Time.deltaTime;
        //    Debug.Log(transform.right * horz * Time.deltaTime);
        //    transform.position = futurePosition;
    }
    public float speed=10;
    public Boundary boundary;

    void FixedUpdate()
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
}

[System.Serializable]
public class Boundary
{
    public float xMin=-28f, xMax=-13f, yMin=-1f, yMax=5f;
}
