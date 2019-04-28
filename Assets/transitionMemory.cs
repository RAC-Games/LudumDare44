using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class transitionMemory : MonoBehaviour
{
    public string nextDoor;
    public bool doTransition;
    public Image blackScreen;

    Animator anim;

    public bool fadeIn;
    public bool fadeOut;
    public float fadeTime;
    // Start is called before the first frame update
    int alpha = 0;
    float elapsed = 0;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        doTransition = true;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //if (fadeIn)
        //{
        //    anim.SetTrigger("fadeIn");
        //    fadeIn = false;
        //}else if (fadeOut)
        //{
        //    anim.SetTrigger("fadeOut");
        //    fadeOut = false;
        //}
    }
}
