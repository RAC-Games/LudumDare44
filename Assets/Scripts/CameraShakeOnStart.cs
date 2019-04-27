using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeOnStart : MonoBehaviour
{
    public float duration;
    public float magnitude;
    
    
    void Start()
    {
        CameraShake cameraShake = FindObjectOfType<CameraShake>();
        if (cameraShake != null)
        {
            StartCoroutine(cameraShake.Shake(duration, magnitude));
        }
    }

}
