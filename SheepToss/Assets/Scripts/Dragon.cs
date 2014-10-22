using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public abstract class Dragon : Character, IMovable, IDestructable
{
    #region Private Members
    private float nextFire;
    private int maxHP;
    private int attack;
    private int armor;
    private int speed;
    private int hp;
    private int coins;
    private int exp;
    private float rateOfFire;
    private int stones;

    private Rect hpBarContainer = new Rect(10, 10, 100, 20);
    private Texture2D hpBarBackground;
    private Texture2D hpBarforeground;
	
    #endregion
	
    public GUIText scoreText;
    public GUIText expText;
    public Font font;

    public Dragon()
    {
        this.Speed = 10;
        this.MaxHP = 2000;
        this.HP = this.MaxHP;
        this.RateOfFire = 0.25f;
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

    public int MaxHP
    {
        get
        {
            return this.maxHP;
        }
        private set
        {
            Utilities.ValidateInt(value, "Max HP");
            this.maxHP = value;
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

    public int Armor
    {
        get
        {
            return this.armor;
        }
        set
        {
            Utilities.ValidateInt(value, "Armor");
            this.armor = value;
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

    public int Coins
    {
        get
        {
            return this.coins;
        }
        set
        {
            Utilities.ValidateInt(value, "Coins");
            this.coins = value;
        }
    }

    public int Stones
    {
        get
        {
            return this.stones;
        }
        set
        {
            Utilities.ValidateInt(value, "Stones");
            this.stones = value;
        }
    }

    public int Exp
    {
        get
        {
            return this.exp;
        }
        set
        {
            Utilities.ValidateInt(value, "Exp");
            this.exp = value;
            UpdateExp();
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
    public Transform Stone;
    public Transform ShotSpawn;

    #endregion

    public override void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        this.rigidbody2D.velocity = movement * this.Speed;

        float xClamp = Mathf.Clamp(this.gameObject.rigidbody2D.position.x, this.Boundary.xMin, this.Boundary.xMax);
        float yClamp = Mathf.Clamp(this.gameObject.rigidbody2D.position.y, this.Boundary.yMin, this.Boundary.yMax);

        this.gameObject.rigidbody2D.position = new Vector2(xClamp, yClamp);
    }

    public void Start()
    {
        InstantiateHPBar();
        DefineBoundaries();
        UpdateScore();
        UpdateExp();
    }

    private void Fire()
    {
        if (Input.GetButton("Fire1") & Time.time > this.NextFire)
        {
            this.NextFire = Time.time + this.RateOfFire;
            Instantiate(this.Shot, this.ShotSpawn.position, this.ShotSpawn.rotation);
        }
        if (Input.GetButton("Fire2") && this.Stones > 0 & Time.time > this.NextFire)
        {
            this.NextFire = Time.time + this.RateOfFire;
            Instantiate(this.Stone, this.ShotSpawn.position, this.ShotSpawn.rotation);
            this.Stones--;
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
        if (Time.timeScale > 0)
        {
            this.HP -= 1;
            if (this.HP > this.maxHP)
            {
                this.HP = this.maxHP;
            }
        }

        if (this.HP < 1)
        {
            this.Destroy();
            Time.timeScale = 0.0f;
        }
    }

    void OnGUI()
    {
        GUI.BeginGroup(hpBarContainer);
        {
            GUI.DrawTexture(new Rect(0, 0, hpBarContainer.width, hpBarContainer.height), hpBarBackground, ScaleMode.StretchToFill);
            GUI.DrawTexture(new Rect(0, 0, hpBarContainer.width * this.HP / this.maxHP, hpBarContainer.height), hpBarforeground, ScaleMode.StretchToFill);
        }
        GUI.EndGroup();
    }

    private void InstantiateHPBar()
    {
        hpBarBackground = new Texture2D(1, 1, TextureFormat.RGB24, false);
        hpBarforeground = new Texture2D(1, 1, TextureFormat.RGB24, false);

        hpBarBackground.SetPixel(0, 0, Color.white);
        hpBarforeground.SetPixel(0, 0, Color.black);

        hpBarBackground.Apply();
        hpBarforeground.Apply();
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
        if (this.HP > 0)
        {
            if (other.gameObject.GetComponent<Package>() != null)
            {
                Package collectedPackage = other.gameObject.GetComponent<Package>();
                this.HP += collectedPackage.LifePoints;
            }
			
            if (other.gameObject.GetComponent<Sheep>() != null)
            {
                Sheep collectedSheep = other.gameObject.GetComponent<Sheep>();
                this.Coins += collectedSheep.Coins;
                UpdateScore();
            }
			
            if (other.gameObject.GetComponent<NPCProjectile>() != null)
            {
                NPCProjectile encounteredProjectile = other.gameObject.GetComponent<NPCProjectile>();
                this.HP -= encounteredProjectile.Damage;
            }
			
            if (other.gameObject.GetComponent<BossProjectile>() != null)
            {
                BossProjectile encounteredProjectile = other.gameObject.GetComponent<BossProjectile>();
                this.HP -= encounteredProjectile.Damage;
            }
        }
    }

    public void UpdateScore()
    {
        scoreText.color = Color.black;
        scoreText.fontSize = 24;
        scoreText.text = "Score: " + this.Coins;
    }

    public void UpdateExp()
    {
        expText.color = Color.black;
        expText.fontSize = 24;
        expText.text = "Exp: " + this.Exp;
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}

[System.Serializable]
public struct Boundary
{
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
}