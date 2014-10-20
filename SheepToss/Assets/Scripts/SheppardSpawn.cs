using UnityEngine;
using System.Collections;

public class SheppardSpawn : MonoBehaviour
{
    public Transform Sheppard;
    public Transform ShepaprdSpawn;
    private float nextSpawn;
    private float rateOfSpawn;

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

    public void Start()
    {
        this.RateOfSpawn = 1;
    }

    public void Update()
    {
        if (UnityEngine.GameObject.FindGameObjectWithTag("Sheppard") == null)
        {
            if (Time.time > this.NextSpawn)
            {
                Instantiate(Sheppard, ShepaprdSpawn.rigidbody2D.position, ShepaprdSpawn.rotation);
            }
        }
    }
}
