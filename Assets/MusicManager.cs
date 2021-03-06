﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    AudioSource hubSong;
    AudioSource actionSong;
    [SerializeField]
    float fadeDuration;
    [SerializeField]
    float maxVolume;
    float startTime;
    float endTime;
    float curTime;
    bool hub = true;
    AnimationCurve hubVolume;
    AnimationCurve actionVolume;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        AudioSource[] sources = GetComponents<AudioSource>();
        hubSong = sources[0];
        actionSong = sources[1];
    }

    // Update is called once per frame
    void Update()
    {
        if (curTime < endTime)
        {
            curTime += Time.deltaTime;
            hubSong.volume = hubVolume.Evaluate(curTime);
            actionSong.volume = actionVolume.Evaluate(curTime);
        }
    }

    public void PlayActionMusic()
    {
        SetDuration();
        actionVolume = AnimationCurve.EaseInOut(startTime, 0, endTime, maxVolume);
        hubVolume = AnimationCurve.EaseInOut(startTime, maxVolume, endTime, 0);
    }

    public void PlayHubMusic()
    {
        SetDuration();
        hubVolume = AnimationCurve.EaseInOut(startTime, 0, endTime, maxVolume);
        actionVolume = AnimationCurve.EaseInOut(startTime, maxVolume, endTime, 0);
    }

    void SetDuration()
    {
        startTime = Time.time;
        endTime = startTime + fadeDuration;
        curTime = startTime;
        maxVolume = Mathf.Clamp(maxVolume, 0, 1);
    }
}
