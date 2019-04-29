using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class returnToHub : MonoBehaviour
{
    public void teleport()
    {
        SceneManager.LoadScene("Hub_1");
    }
}
s