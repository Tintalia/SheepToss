using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public abstract class Dragon : Character, ILivable, IMovable
{
    private float nextFire;
    private readonly float maxHP = 500f;
    //other private fields to be added
    public int Attack { get; set; } //Projectile attack value + bonuses (if there are any)
    public int Speed { get; set; }
    public int Armor { get; set; }
    public int Firepower { get; set; }
    public int ShotLimit { get; set; }
    public int Venom { get; set; }
    public int JawStrength { get; set; }
    public int Stealth { get; set; }
    public float HP { get; set; }
    public int Coins { get; set; }
    public int Exp { get; set; }

    public float speed = 10;
    public Boundary boundary;
    public Transform shot;
    public Transform shotSpawn;
    public float rateOfFire;
    Rect box = new Rect(10, 10, 100, 20);
    private Texture2D background;
    private Texture2D foreground;

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

    void Start()
    {
        this.HP = this.maxHP;
        background = new Texture2D(1, 1, TextureFormat.RGB24, false);
        foreground = new Texture2D(1, 1, TextureFormat.RGB24, false);

        background.SetPixel(0, 0, Color.red);
        foreground.SetPixel(0, 0, Color.green);

        background.Apply();
        foreground.Apply();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") & Time.time > nextFire)
        {
            nextFire = Time.time + rateOfFire;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }

    void FixedUpdate()
    {
        this.Move();
        this.UpdateHP();
    }

    private void UpdateHP()
    {
        this.HP -= 0.8f;
        if (this.HP < 0)
        {
            Destroy(gameObject);//here goes the falling dragon animation
            Time.timeScale = 0.0f;
        }
    }

    void OnGUI()
    {
        GUI.BeginGroup(box);
        {
            GUI.DrawTexture(new Rect(0, 0, box.width, box.height), background, ScaleMode.StretchToFill);
            GUI.DrawTexture(new Rect(0, 0, box.width * this.HP / this.maxHP, box.height), foreground, ScaleMode.StretchToFill);
        }
        GUI.EndGroup(); ;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.ToString().Contains("Package"))
        {
            this.HP += 100;
        }
        if (other.gameObject.GetComponent<Sheep>() != null)
        {
            this.Coins += other.gameObject.GetComponent<Sheep>().coins;
        }
        if (other.gameObject.GetComponent<NPCProjectile>() != null)
        {
            this.HP -= other.gameObject.GetComponent<NPCProjectile>().Attack;
        }
    }
}

[System.Serializable]
public class Boundary
{
    public float xMin = -28f, xMax = -13f, yMin = -1f, yMax = 5f;
}