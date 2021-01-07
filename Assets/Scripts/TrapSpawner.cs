using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawner : MonoBehaviour
{
    public List<Obstacle> traps;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            SpawnTrap();
        }
    }

    public void SpawnTrap()
    {
        Obstacle chosenObstacle = traps[(int)Random.Range(0, traps.Count)];
        float randSize = Random.Range(chosenObstacle.minSize, chosenObstacle.maxSize);
        Vector3 randPos = new Vector3(transform.position.x + Random.Range(-10f, 10f), transform.position.y, transform.position.z + Random.Range(-10f, 0f));
        GameObject spawned = Instantiate(chosenObstacle.objectPrefab, randPos, Quaternion.identity) as GameObject;
        spawned.transform.localScale = new Vector3(randSize, randSize, randSize);
        spawned.GetComponent<SimpleForce>().AddForce();
    }

    public void SpawnTrap(Vector3 spawnPosition)
    {
        Obstacle chosenObstacle = traps[(int)Random.Range(0, traps.Count)];
        float randSize = Random.Range(chosenObstacle.minSize, chosenObstacle.maxSize);
        GameObject spawned = Instantiate(chosenObstacle.objectPrefab, spawnPosition, Quaternion.identity) as GameObject;
        spawned.transform.localScale = new Vector3(randSize, randSize, randSize);
        spawned.GetComponent<SimpleForce>().AddForce();
    }
}