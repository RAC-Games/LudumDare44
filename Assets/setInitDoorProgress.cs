using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setInitDoorProgress : MonoBehaviour
{
    public progressSO progress;
    // Start is called before the first frame update
    void Start()
    {
        progress.door1 = true;
        progress.door2 = false;
        progress.door3 = false;
        progress.door4 = false;
        progress.doorHub = true;
        progress.doorBoss = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
