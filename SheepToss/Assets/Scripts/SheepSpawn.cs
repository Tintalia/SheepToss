using UnityEngine;
using System.Collections;
using System;

public class SheepSpawn : MonoBehaviour
{
    #region Private Members
    private float nextSpawn;
    private float rateOfSpawn;
    float spawnPositionX;
    #endregion

    #region Public Members
    public Transform WhiteSheep;
    public Transform BlackSheep;
    public Transform GoldenSheep;

    public float NextSpawn
    {
        get
        {
            return this.nextSpawn;
        }
        set
        {
            Utilities.ValidateFloat(value, "Next spawn");
            this.nextSpawn = value;
        }
    }

    public float RateOfSpawn
    {
        get
        {
            return this.rateOfSpawn;
        }
        set
        {
            Utilities.ValidateFloat(value, "Rate of spawn");
            this.rateOfSpawn = value;
        }
    }

    public float SpawnPositionX
    {
        get
        {
            return this.spawnPositionX;
        }
        set
        {
            this.spawnPositionX = value;
        }
    }

    private void SpawnSheep()
    {
        System.Random random = new System.Random();

        if (Time.time > this.NextSpawn)
        {
            this.NextSpawn = Time.time + this.RateOfSpawn;
            if (random.Next(1, 100) < 50)
            {
                Instantiate(WhiteSheep, new Vector2(spawnPositionX, random.Next(-4, 5)), new Quaternion());
            }
            else if (random.Next(1, 100) < 85)
            {
                Instantiate(BlackSheep, new Vector2(spawnPositionX, random.Next(-4, 5)), new Quaternion());
            }
            else
            {
                Instantiate(GoldenSheep, new Vector2(spawnPositionX, random.Next(-4, 5)), new Quaternion());
            }
        }
    }
    #endregion

    public void Start()
    {
        this.SpawnPositionX = Camera.main.rigidbody2D.position.x + 7;
        this.RateOfSpawn = 2;
    }

    public void Update()
    {
        this.SpawnSheep();
    }
}
