using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartUI : MonoBehaviour
{
    public Health playerHealth;
    public GameObject fullHeart;
    public GameObject[] fullHearts;
    public GameObject heartGrid;
    public int maxHealth = 15;


    public void UpdateHearts()
    {
        for(int i = 0; i < maxHealth; i++)
        {
            if (i < playerHealth.health)
            {
                fullHearts[i].GetComponent<Image>().enabled = true;
            }
            else
            {
                fullHearts[i].GetComponent<Image>().enabled = false;
            }
        }
    }
}
