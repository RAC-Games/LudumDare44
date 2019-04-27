using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startBuyScreen : MonoBehaviour
{
    public Image image;
    public Text textField;
    public GameObject panel;

    Coroutine typewriterRoutine;
    bool waitForSpace = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waitForSpace)
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponentInParent<movement>().enabled = false;
            other.GetComponentInParent<PlayerAttack>().enabled = false;

            textField.text = "";
            panel.SetActive(true);

            typewriterRoutine = StartCoroutine(typeText("Hallo ich bims eins Schreibmaschine! Willst du etwas kaufen mein Freund? Guckst du hier..."));
            print("lol");
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        StopCoroutine(typewriterRoutine);
        textField.text = "";
        textField.text = "bye";
        Invoke("disablePanel", 1);
    }

    void disablePanel() {
        panel.SetActive(false);
    }

    IEnumerator typeText(string textString) {
        var charArray = textString.ToCharArray();
        var index = 0;

        while (index < charArray.Length)
        {
            textField.text = textField.text + charArray[index];
            index++;
            yield return new WaitForSeconds(.01f);
        }
        waitForSpace = true;
    }
}
