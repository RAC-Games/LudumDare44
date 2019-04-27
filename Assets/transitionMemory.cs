using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transitionMemory : MonoBehaviour
{
    public string nextDoor;
    public bool doTransition;
    // Start is called before the first frame update
    void Start()
    {
        doTransition = true;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
