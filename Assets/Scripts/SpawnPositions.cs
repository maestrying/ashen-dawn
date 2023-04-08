using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPositions : ScriptableObject
{
    public Dictionary<string, Vector3> positions = new Dictionary<string, Vector3>()
    {
        {"2-3", new Vector3(3,3,3)}
    };
}
