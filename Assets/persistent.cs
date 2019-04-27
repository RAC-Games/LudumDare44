using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class persistent : MonoBehaviour
{
    public string cameFrom;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

}
