using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "HyperCasualGuys/Sequence/SpawnSequence")]
public class SpawnSequence : Sequence
{
    public SpawnType spawnType;
    public float mummySpawnFrequency;
    private float curChronoMummySpawn;

    private int spawnColorIndex = 0;

    public override void StartSequence()
    {
        curChrono = chronoSequence;
        curChronoMummySpawn = mummySpawnFrequency;
        spawnColorIndex = Random.Range(0, 5);
    }

    public override bool Execute()
    {
        curChrono -= Time.deltaTime;
        if (curChrono <= 0f)
        {
            return true;
        }
        else
        {
            curChronoMummySpawn -= Time.deltaTime;
            if(curChronoMummySpawn<=0f)
            {
                //SPAWN
                spawnerManager?.SpawnMummy(spawnType, spawnColorIndex);
                curChronoMummySpawn = mummySpawnFrequency;
            }
            return false;
        }
    }
}

public enum SpawnType
{
    RANDOM,
    LEFT,
    RIGHT,
    MIDDLE,
    LEFT_RIGHT
}
