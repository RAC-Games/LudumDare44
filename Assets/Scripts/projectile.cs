using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    
    Rigidbody rb;

    public void shoot(Vector3 startPosition, Vector3 targetPosition,  GameObject gameObject, float speed = 50)
    {
        GameObject instance = Instantiate(gameObject, startPosition, transform.rotation);
        rb = instance.GetComponent<Rigidbody>();
        rb.AddForce(speed*(targetPosition),ForceMode.Impulse);
        Destroy(instance, 1);
    }
}
