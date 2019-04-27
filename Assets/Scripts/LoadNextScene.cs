using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    public string szenenNamen;
    public int door;
    public GameObject player;
    public float distance;

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(this.transform.position, player.transform.position) < distance)
        {
            print("E");
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(szenenNamen);
            }
        }

        
        

    }
}
