using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Sequence : ScriptableObject
{
    public float chronoSequence;
    protected float curChrono;

    public MummySpawner spawnerManager { get; set; }

    public abstract void StartSequence();

    /// <summary>
    /// call in update
    /// </summary>
    /// <returns>true if sequence is ended</returns>
    public abstract bool Execute();
}
