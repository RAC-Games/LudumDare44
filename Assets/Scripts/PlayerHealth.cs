using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public Health healthSO;

    private void Start()
    {
        healthSO.health = 10;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            healthSO.decreaseHealth(1);
            print(healthSO.health);
        }
    }
}
