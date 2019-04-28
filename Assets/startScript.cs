using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startScript : MonoBehaviour
{
    public GameObject player;
    public void StartGame() {
        player.SetActive(true);
        SceneManager.LoadScene("Hub_1");
    }
}
