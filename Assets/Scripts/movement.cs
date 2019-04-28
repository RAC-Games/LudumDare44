using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    
    public GameObject mouseHit;
    Rigidbody rb;

    Vector3 rotation = new Vector3(0, 0, 0);
    Vector2 oldInput;
    float angle;

    public float speed;
    // Start is called before the first frame update
    Vector3 offset;
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        var memoryGO = GameObject.FindGameObjectWithTag("memory");

        var memory = memoryGO.GetComponent<transitionMemory>();
        memory.fadeOut = true;
        var spawName = memory.nextDoor;
        var door = GameObject.Find(spawName);
        if (spawName == "HubTeleport") { return; }
        var spawnTransform = door.transform.GetChild(0);
        transform.position = spawnTransform.transform.position;


    }

    void Start()
    {
        offset =  camera.transform.position- transform.position;
        Vector2 oldInput = new Vector2(0, 0);
        rb = GetComponent<Rigidbody>();
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(camera.gameObject);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var direction = new Vector3(horizontal, 0, vertical);
        rb.MovePosition(transform.position + direction * Time.deltaTime * speed);

        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        var mask = LayerMask.GetMask("ground");
        if (Physics.Raycast(ray, out hit))
        {
            if (!hit.transform.CompareTag("Player"))
            {
                if (mouseHit != null)
                {

                    mouseHit.transform.position = hit.point;
                }
                transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
            }

        }
    }

    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        camera.transform.position = transform.position + offset;
    }

    
}