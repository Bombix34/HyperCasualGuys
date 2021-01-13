using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "HyperCasualGuys/Sequence/WaitSequence")]
public class WaitSequence : Sequence
{
    public override void StartSequence()
    {
        curChrono = chronoSequence;
    }

    public override bool Execute()
    {
        curChrono -= Time.deltaTime;
        if (curChrono <= 0f)
        {
            return true;
        }
        else
            return false;
    }
}
