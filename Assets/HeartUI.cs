using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartUI : MonoBehaviour
{
    public Health playerHealth;
    public GameObject[] fullHearts;
    public GameObject[] emptyHearts;
    public GameObject heartGrid;
    


    public void UpdateHearts()
    {
        for(int i = 0; i < playerHealth.maxHealth; i++)
        {
            if (i < playerHealth.health)
            {
                fullHearts[i].GetComponent<Image>().enabled = true;
                emptyHearts[i].GetComponent<Image>().enabled = false;

            }
            else
            {
                fullHearts[i].GetComponent<Image>().enabled = false;
                emptyHearts[i].GetComponent<Image>().enabled = true;
            }
        }
    }
}
