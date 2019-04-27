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
        if (collision.gameObject.CompareTag("Projectile") && !(collision.gameObject.GetComponent<damage>().isFromPlayer))
        {
            int dmg = collision.gameObject.GetComponent<damage>().dmg;
            print(dmg);

            healthSO.decreaseHealth(dmg);
            print(healthSO.health);
        }
    }
}
