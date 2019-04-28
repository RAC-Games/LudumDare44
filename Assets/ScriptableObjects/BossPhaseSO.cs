using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "bossPhase", menuName = "scriptableObjects/bossPhase", order = 1)]
public class BossPhaseSO : ScriptableObject
{
    public int count;
    public float splitTime;
    public bool recursion;
    public float attackFrequency;
}
