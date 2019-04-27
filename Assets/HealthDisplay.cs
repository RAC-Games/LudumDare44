using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public Health playerHealth;
    public Image heart;
    // Update is called once per frame

    void Update()
    {
        for(int i = 1;i < playerHealth.health; i++)
        {
            Instantiate(heart, transform.position + i*new Vector3(-10,0,0), transform.rotation, transform);
        }
    }
}
