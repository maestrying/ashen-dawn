using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SpawnPositions : ScriptableObject
{
    [Serializable] 
    public struct lastCharacterScenePositions
    {
        public int indexScene;
        public Vector3 position;
    }
    public lastCharacterScenePositions[] Scenes;
}
