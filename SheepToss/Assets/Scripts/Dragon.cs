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

    public void Update()
    {
        Move();
    }
    public override void Move()
    {
        var horz = Input.GetAxis("Horizontal");
        var vert = Input.GetAxis("Vertical");
        transform.position += (transform.right * horz + transform.up * vert) * 10 * Time.deltaTime;
    }
}
