using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class AdjustVolume : MonoBehaviour
{
    public Slider volslider;
    public AudioListener vol;

    public void SliderToVol()
    {
        vol.volume = Mathf.Log10(volslider.value) * 20;
    }
}