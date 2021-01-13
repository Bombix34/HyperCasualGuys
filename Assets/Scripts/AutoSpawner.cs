using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSpawner : MonoBehaviour
{
    public LevelSpawnerSequence currentLevelSequence;
    private int currentSequenceIndex = -1;

    MummySpawner mummySpawner;

    private void Awake()
    {
        mummySpawner = GetComponentInChildren<MummySpawner>();
    }

    private void Start()
    {
        LoadNextSequence();
    }

    private void Update()
    {
        //UPDATE SEQUENCE EN COURS
        if(currentLevelSequence.levelSequence[currentSequenceIndex].Execute())
        {
            //SEQUENCE FINIE
            LoadNextSequence();
        }
    }

    private void LoadNextSequence()
    {
        if(currentSequenceIndex+1 >= currentLevelSequence.levelSequence.Count)
        {
            //FIN DU LEVEL
            Debug.Log("END LEVEL");
            return;
        }
        currentSequenceIndex++;
        currentLevelSequence.levelSequence[currentSequenceIndex].spawnerManager = mummySpawner;
        currentLevelSequence.levelSequence[currentSequenceIndex].StartSequence();
    }
}
