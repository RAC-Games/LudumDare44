using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "dialog", menuName = "scriptableObjects/dialog", order = 1)]
public class DialogSO : ScriptableObject
{
    public List<TurnToSpeak> dialogList = new List<TurnToSpeak>();
    public bool endWithBuyScreen;
    public int currentSpeakerIndex;
}
