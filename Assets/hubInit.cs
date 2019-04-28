using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hubInit : MonoBehaviour
{
    public progressSO progress;
    public GameObject doorHub;
    public GameObject doorHubClosed;
    public GameObject door1;
    public GameObject door1Closed;
    public GameObject door2;
    public GameObject door2Closed;
    public GameObject door3;
    public GameObject door3Closed;
    public GameObject door4;
    public GameObject door4Closed;
    public GameObject doorBoss;
    public GameObject doorBossClosed;

    public DialogSO level1;
    public DialogSO level2;
    public DialogSO level3;
    public DialogSO level4;
    public DialogSO levelBoss;
    public DialogSO waiting;

    public startBuyScreen buyDialog;
    // Start is called before the first frame update
    void Start()
    {
        init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void init() {
        doorHub.SetActive(progress.doorHub);
        doorHubClosed.SetActive(!progress.doorHub);
        door1.SetActive(progress.door1);
        door1Closed.SetActive(!progress.door1);
        door2.SetActive(progress.door2);
        door2Closed.SetActive(!progress.door2);
        door3.SetActive(progress.door3);
        door3Closed.SetActive(!progress.door3);
        door4.SetActive(progress.door4);
        door4Closed.SetActive(!progress.door4);
        doorBoss.SetActive(progress.doorBoss);
        doorBossClosed.SetActive(!progress.doorBoss);

        if (progress.door4)
        {
            buyDialog.dialog = levelBoss;
        }else if (progress.door3)
        {
            buyDialog.dialog = level4;
        }
        else if (progress.door2)
        {
            buyDialog.dialog = level3;
        }
        else if (progress.door1)
        {
            buyDialog.dialog = level2;
        }
    }
}
