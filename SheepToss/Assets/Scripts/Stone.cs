using System;
using UnityEngine;

class Stone : Item
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Sheppard>() != null)
        {
            other.gameObject.GetComponent<Sheppard>().HP = 0;
        }
    }
}