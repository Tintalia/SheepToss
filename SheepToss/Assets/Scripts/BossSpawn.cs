using UnityEngine;
using System.Collections;

public class BossSpawn : MonoBehaviour
{
    public Transform boss;
    public Transform bossSpawn;
    private bool isBossInstantiated;
    private int instantiatedAtExp;

    public bool IsBossInstantiated
    {
        get
        {
            return this.isBossInstantiated;
        }
        set
        {
            this.IsBossInstantiated = value;
        }
    }

    void Update()
    {
        if (UnityEngine.GameObject.FindGameObjectWithTag("Player") != null)
        {
            if (UnityEngine.GameObject.FindGameObjectWithTag("Player").GetComponent<Dragon>().Exp != 0)
            {
                if (UnityEngine.GameObject.FindGameObjectWithTag("Player").GetComponent<Dragon>().Exp % 300 == 0)
                {
                    if (UnityEngine.GameObject.FindGameObjectWithTag("Boss") == null && isBossInstantiated == false
                        && this.instantiatedAtExp != UnityEngine.GameObject.FindGameObjectWithTag("Player").GetComponent<Dragon>().Exp)
                    {
                        Debug.Log("Instantiated");
                        Instantiate(boss, boss.rigidbody2D.position, new Quaternion());
                        isBossInstantiated = true;
                        instantiatedAtExp = UnityEngine.GameObject.FindGameObjectWithTag("Player").GetComponent<Dragon>().Exp;
                    }
                    else
                    {
                        isBossInstantiated = false;
                    }
                }
            }
        }
    }
}
