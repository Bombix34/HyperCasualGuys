using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "HyperCasualGuys/new level sequence")]
public class LevelSpawnerSequence : ScriptableObject
{
    public List<Sequence> levelSequence;
}
