﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class startBuyScreen : MonoBehaviour
{
    public GameObject imageHero;
    public GameObject imageVendor;
    public Text textField;
    public GameObject panel;
    public GameObject dropDown;
    public DialogSO dialog;
    public GameObject buyButtons;
    public UnityEvent OnEnd;
    public bool shouldDestroy;

    Collider ColliderObj;
    Coroutine typewriterRoutine;
    bool waitForSpace = false;
    // Start is called before the first frame update
    void Start()
    {
        dialog.currentSpeakerIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (waitForSpace)
        {
            if (Input.anyKey)
            {
                waitForSpace = false;
                if (dialog.currentSpeakerIndex<dialog.dialogList.Count)
                {
                    StartDialog();
                }
                else
                {
                    if (dialog.endWithBuyScreen)
                    {
                        buyButtons.SetActive(true);
                        waitForSpace = false;
                        dropDown.SetActive(true);
                    }
                    else {
                        disableDialog();
                    }
                    
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ColliderObj = other;
            other.GetComponentInParent<movement>().enabled = false;
            other.GetComponentInParent<PlayerAttack>().enabled = false;
            dialog.currentSpeakerIndex = 0;

            panel.SetActive(true);

            StartDialog();
        }
    }

    void StartDialog() {
        typewriterRoutine = StartCoroutine(typeText(dialog.dialogList[dialog.currentSpeakerIndex].text, dialog.dialogList[dialog.currentSpeakerIndex].turnOf));
    }
    
    private void OnTriggerExit(Collider other)
    {
        //StopCoroutine(typewriterRoutine);
        //textField.text = "";
        //textField.text = "bye";
        //Invoke("disablePanel", 1);
    }

    void disablePanel() {
        panel.SetActive(false);
    }

    IEnumerator typeText(string textString, TurnOf turnOf) {
        var charArray = textString.ToCharArray();
        var index = 0;
        textField.text = "";
        if (turnOf == TurnOf.Player)
        {
            imageHero.SetActive(true);
            imageVendor.SetActive(false);
        }
        else {
            imageHero.SetActive(false);
            imageVendor.SetActive(true);
        }

        while (index < charArray.Length)
        {
            textField.text = textField.text + charArray[index];
            index++;
            yield return new WaitForSeconds(.01f);
        }
        dialog.currentSpeakerIndex++;
        waitForSpace = true;
        dropDown.SetActive(true);
    }

    public void BuyKey() {
        disableDialog();
        buyButtons.SetActive(false);
    }
    public void BuyCooldown() {
        disableDialog();
        buyButtons.SetActive(false);
    }

    void disableDialog() {
        panel.SetActive(false);
        dropDown.SetActive(false);
        buyButtons.SetActive(false);
        ColliderObj.GetComponentInParent<movement>().enabled = true;
        ColliderObj.GetComponentInParent<PlayerAttack>().enabled = true;
        OnEnd.Invoke();
        if (shouldDestroy)
        {
            Destroy(gameObject, 1);
        }
    }
}
