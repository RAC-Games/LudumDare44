using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    public GameObject pauseScreen;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseScreen.SetActive(true);
        }
        
    }

    public void quitApp()
    {
        Application.Quit();
    }

    public void goBack()
    {
        pauseScreen.SetActive(false);
    }
}
