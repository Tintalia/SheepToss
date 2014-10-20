using UnityEngine;
using System.Collections;

public class BossSpawn : MonoBehaviour
{
    public Transform boss;
    public Transform bossSpawn;
    private bool isBossInstantiated;

    void Update()
    {
        if (UnityEngine.GameObject.FindGameObjectWithTag("Player") != null)
        {
            if (UnityEngine.GameObject.FindGameObjectWithTag("Player").GetComponent<Dragon>().Exp >= 100)
            {
                if (!isBossInstantiated)
                {
                    Instantiate(boss, boss.rigidbody2D.position, new Quaternion());
                    isBossInstantiated = true;
                }
            }
        }
    }
}
