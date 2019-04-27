using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TurnOf
{
    Player=0,
    Vendor,
    Enemy
}
[Serializable]
public class TurnToSpeak
{
    public string text;
    public TurnOf turnOf;
}
