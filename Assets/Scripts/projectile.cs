using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    
    Rigidbody rb;

    public void shoot(Vector3 startPosition, Vector3 targetPosition,  GameObject gameObject)
    {
        GameObject instance = Instantiate(gameObject, startPosition, new Quaternion(0,0,0,0));
        rb = instance.GetComponent<Rigidbody>();
        rb.AddForce(50*(targetPosition),ForceMode.Impulse);
        Destroy(instance, 1);
    }
}
