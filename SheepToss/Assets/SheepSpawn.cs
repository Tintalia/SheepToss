using UnityEngine;
using System.Collections;
using System;

public class SheepSpawn : MonoBehaviour
{
    public Transform WhiteSheep;
    public Transform BlackSheep;
    public Transform GoldenSheep;
    public float nextSpawn;
    public float rateOfSpawn;

    void Update()
    {
        float spawnPositionX = Camera.main.rigidbody2D.position.x + 7;
        System.Random random = new System.Random();
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + rateOfSpawn;
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
}
