﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    public Camera camera;
    public GameObject mouseHit;
    Rigidbody rb;
    HeartUI healthUi;
    public Health healthSO;

    Vector3 rotation = new Vector3(0, 0, 0);
    Vector2 oldInput;
    float angle;

    public float speed;
    MusicManager musicManager;
    CameraController cameraController;
    float prevY = 0;
    // Start is called before the first frame update

    Vector3 offset;

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        healthUi = player.GetComponentInChildren<HeartUI>();
        healthUi.UpdateHearts();

        var memoryGO = GameObject.FindGameObjectWithTag("memory");

        var memory = memoryGO.GetComponent<transitionMemory>();
        memory.fadeOut = true;
        var spawName = memory.nextDoor;
        var door = GameObject.Find(spawName);
        if (spawName == "HubTeleport") {
            var go = GameObject.Find(spawName);
            transform.position = go.transform.position + Vector3.up* GetComponent<CapsuleCollider>().height/2;
            healthSO.health = healthSO.maxHealth;
            healthUi.UpdateHearts();
            return;
        }
        var spawnTransform = door.transform.GetChild(0);
        print(spawnTransform.position);
        transform.position = spawnTransform.transform.position + Vector3.up*GetComponent<CapsuleCollider>().height/2;


    }


    void Start()
    {
        cameraController = camera.GetComponent<CameraController>();
        cameraController.setOffset(GameObject.Find("CameraLookAtOffset").transform);
        offset =  camera.transform.position- transform.position;
        Vector2 oldInput = new Vector2(0, 0);
        rb = GetComponent<Rigidbody>();
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(camera.gameObject);
        musicManager = FindObjectOfType<MusicManager>();
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
        Vector3 velocity = rb.velocity;
        velocity.y = Mathf.Clamp(velocity.y, -99999, 0);
        rb.velocity = velocity;
    }

    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        Vector3 pos = transform.position + offset;
        pos.y = camera.transform.position.y;
        camera.transform.position = pos;
        if (prevY != transform.position.y)
        {
            cameraController.Scroll(0);
        }
        prevY = transform.position.y;
    }

    
}