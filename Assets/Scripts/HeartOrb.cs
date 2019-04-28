using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartOrb : MonoBehaviour
{
    // Start is called before the first frame update

    float maxPointTime;
    float preMaxPointTime;
    float StartDistance;
    //[SerializeField]
    float flyDuration;//=3;
    GameObject player;
    [SerializeField]
    float distancePercentageMaximum;
    [SerializeField]
    float distancePercentageMaximumBegin;
    float timeStart;
    Vector3 startPos;
    float curTime;
    [SerializeField]
    float heightAbovePlayer;
    [SerializeField]
    float speed;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        flyDuration = speed / getDistance();
        timeStart = Time.time;
        curTime = timeStart;
        startPos = transform.position;
        maxPointTime = (timeStart + flyDuration) * distancePercentageMaximum;
        preMaxPointTime = (timeStart + flyDuration) * distancePercentageMaximumBegin;
        Debug.Log(flyDuration);

    }

    // Update is called once per frame
    void Update()
    {
        if (curTime < flyDuration + timeStart)
        {
            curTime += Time.deltaTime;
            transform.LookAt(GameObject.Find("player").transform);
            Vector3 pos = Vector3.zero;
            pos.x = AnimationCurve.EaseInOut(timeStart, startPos.x, flyDuration + timeStart, player.transform.position.x).Evaluate(curTime);
            AnimationCurve yValue = AnimationCurve.EaseInOut(timeStart, heightAbovePlayer + timeStart, flyDuration + timeStart, player.transform.position.y + startPos.y);
            yValue.AddKey(preMaxPointTime, player.transform.position.y + heightAbovePlayer * 0.3f);
            yValue.AddKey(maxPointTime, player.transform.position.y + heightAbovePlayer);
            pos.y = yValue.Evaluate(curTime);
            pos.z = AnimationCurve.EaseInOut(timeStart, startPos.z, flyDuration + timeStart, player.transform.position.z).Evaluate(curTime);
            transform.position = pos;
        }
        else
        {
            Absorb();
        }
    }

    float getDistance()
    {
        return Mathf.Abs((transform.position - player.transform.position).magnitude);
    }

    void Absorb()
    {

        player.GetComponent<PlayerHealth>().healthSO.increaseHealth();
        Destroy(gameObject);
    }
}
