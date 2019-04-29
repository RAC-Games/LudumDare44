using System;
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
    public progressSO progress;
    public Health health;

    public UnityEvent OnButton1;

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
                dropDown.SetActive(false);
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
                        progress.Progress();
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
        setNextDoor();
        OnButton1.Invoke();
        disableDialog();
        buyButtons.SetActive(false);
    }

    private void setNextDoor()
    {
        print("setNextDoor");
        if (!progress.door1)
        {
            progress.door1 = true;
            health.decreaseHealth(1);
            health.decreaseMaxHealth(1);
        }
        else if (!progress.door2)
        {
            progress.door2 = true;
            health.decreaseHealth(2);
            health.decreaseMaxHealth(2);
        }
        else if (!progress.door3)
        {
            progress.door3 = true;
            health.decreaseHealth(2);
            health.decreaseMaxHealth(2);
        }
        else if (!progress.door4)
        {
            progress.door4 = true;
            health.decreaseHealth(2);
            health.decreaseMaxHealth(2);
        }
        else if (!progress.doorBoss)
        {
            health.decreaseHealth(3);
            health.decreaseMaxHealth(3);
            progress.doorBoss = true;
        }

        var player = GameObject.FindGameObjectWithTag("Player");
        var healthUi = player.GetComponentInChildren<HeartUI>();
        healthUi.UpdateHearts();
    }

    public void BuyCooldown() {
        var memory = GameObject.Find("transitionMemory").GetComponent<transitionMemory>();
        memory.doTransition = true;
        disableDialog();
        buyButtons.SetActive(false);
    }

    void disableDialog() {
        panel.SetActive(false);
        dropDown.SetActive(false);
        buyButtons.SetActive(false);
        ColliderObj.GetComponentInParent<movement>().enabled = true;
        ColliderObj.GetComponentInParent<PlayerAttack>().enabled = true;
        GameObject.Find("transitionMemory").GetComponent<transitionMemory>().doTransition = true;
        OnEnd.Invoke();
        if (shouldDestroy)
        {
            Destroy(gameObject);
        }
    }
}
