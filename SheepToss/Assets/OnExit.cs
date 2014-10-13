using UnityEngine;
using System.Collections;

public class OnExit : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D otherCollider)
    {
        Destroy(otherCollider.gameObject);
    }
}