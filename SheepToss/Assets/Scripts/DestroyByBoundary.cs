using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

    void OnTriggerExit(Collider otherCollider)
    {
        Debug.Log("Detected by the 3D Collider");
    }
}
