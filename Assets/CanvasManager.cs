using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public GameObject healthCanvas;

    private void OnEnable()
    {
        if(SceneManager.GetActiveScene().buildIndex != 0)
        {
            healthCanvas.SetActive(true);
            healthCanvas.GetComponent<HeartUI>().UpdateHearts();
            
        }
    }

}
