using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class sceneTransition : MonoBehaviour
{
    public transitionMemory memory;
    public SpawnListSO SpawnList;
    public bool goingIn;

    private void OnEnable()
    {
        if (memory == null)
        {
            memory = GameObject.Find("transitionMemory").GetComponent<transitionMemory>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (memory == null)
        {
            memory = GameObject.Find("transitionMemory").GetComponent<transitionMemory>();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit(Collider other)
    {
        memory.doTransition = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(transform.parent.name + " OnTriggerEnter");
        if (!memory.doTransition)
            return;

        Debug.Log("memory doTransition = true");
        if (other.CompareTag("Player"))
        {
            memory.doTransition = false;
            var fromScene = SceneManager.GetActiveScene().name;
            var fromDoor = transform.parent.name;
            SpawnConnection connection;
            if (goingIn)
            {
                connection = SpawnList.spawnConnections.Find(element =>
                  element.fromScene == fromScene && element.fromDoor == fromDoor
                );
                if (connection == null)
                {
                    Debug.Log("No connection");
                    return;
                }
                memory.nextDoor = connection.toDoor;
                memory.fadeIn = true;

                SceneManager.LoadScene(connection.toScene, LoadSceneMode.Single);
            }
            else
            {
                connection = SpawnList.spawnConnections.Find(element =>
                    element.toScene == fromScene && element.toDoor == fromDoor
                );
                memory.nextDoor = connection.fromDoor;
                memory.fadeIn = true;

                SceneManager.LoadScene(connection.fromScene, LoadSceneMode.Single);
            }



        }
    }

    public void teleportToHub()
    {
        memory.nextDoor = "HubTeleport";
        memory.fadeIn = true;

        SceneManager.LoadScene("Hub_1", LoadSceneMode.Single);
    }
}
