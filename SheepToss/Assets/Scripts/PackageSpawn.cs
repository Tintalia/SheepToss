using UnityEngine;
using System.Collections;
using System;

public class PackageSpawn : MonoBehaviour
{
    public Transform package;
    public float nextSpawn;
    public float rateOfSpawn;

    void Update()
    {
        float spawnPositionY = 5;
        System.Random random = new System.Random();
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + rateOfSpawn;
            Instantiate(package, new Vector2(random.Next(-30,2), spawnPositionY), new Quaternion());
        }
    }
}
