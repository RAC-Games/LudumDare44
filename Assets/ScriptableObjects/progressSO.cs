using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "progress", menuName = "scriptableObjects/progress", order = 1)]
public class progressSO : ScriptableObject
{
    public bool doorHub;
    public bool door1;
    public bool door2;
    public bool door3;
    public bool door4;
    public bool doorBoss;

    public void setDoorHub(bool val) {
        doorHub = val;
    }
    public void setDoor1(bool val)
    {
        door1 = val;
    }
    public void setDoor2(bool val)
    {
        door2 = val;
    }
    public void setDoor3(bool val)
    {
        door3 = val;
    }
    public void setDoor4(bool val)
    {
        door4 = val;
    }
    public void setDoorBoss(bool val)
    {
        doorBoss = val;
    }

    public void Progress()
    {
        if (!door1)
        {
            door1 = true;
            return;
        }
        if (!door2)
        {
            door2 = true;
            return;
        }
        if (!door3)
        {
            door3 = true;
            return;
        }
        if (!door4)
        {
            door4 = true;
            return;
        }
        if (!doorBoss)
        {
            doorBoss = true;
            return;
        }

    }
}
