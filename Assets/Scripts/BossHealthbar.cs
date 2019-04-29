using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthbar : MonoBehaviour
{
    [SerializeField]
    GameObject HpBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHP(float percentage)
    {
        Vector3 scale = HpBar.transform.localScale;
        scale.x = percentage;
        HpBar.transform.localScale = scale;
    }
}
