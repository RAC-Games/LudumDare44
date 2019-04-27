using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpawnConnection {
    public string fromScene;
    public string fromDoor;
    public string toScene;
    public string toDoor;
}

[CreateAssetMenu(fileName = "spawnlist", menuName = "scriptableObjects/spawnlist", order = 1)]
public class SpawnListSO : ScriptableObject
{
    public List<SpawnConnection> spawnConnections = new List<SpawnConnection>();
}
