using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "health", menuName = "scriptableObjects/health", order = 1)]
public class Health : ScriptableObject
{
    public int health = 10;
    public int maxHealth = 15;

    public void decreaseHealth(int damageAmount)
    {
        health = Mathf.Max(0, health - damageAmount);
    }

    public void increaseHealth()
    {
        health += 1;
    }
}
