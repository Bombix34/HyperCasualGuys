using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummySpawner : MonoBehaviour
{
    public GameObject mummyPrefab;

    public Transform target;
    Vector3 targetPos;

    private void Awake()
    {
        targetPos = target.position;
    }

    public void SpawnMummy(SpawnType spawnType, int mummyColor)
    {
        Vector3 randPos = Vector3.zero;
        switch(spawnType)
        {
            case SpawnType.LEFT:
                randPos = new Vector3(transform.position.x + Random.Range(-15f, -5f), transform.position.y, transform.position.z + Random.Range(-10f, 0f));
                break;
            case SpawnType.RIGHT:
                randPos = new Vector3(transform.position.x + Random.Range(5f, 15f), transform.position.y, transform.position.z + Random.Range(-10f, 0f));
                break;
            case SpawnType.MIDDLE:
                randPos = new Vector3(transform.position.x + Random.Range(-5f, 5f), transform.position.y, transform.position.z + Random.Range(-10f, 0f));
                break;
            case SpawnType.LEFT_RIGHT:
                int rand = Random.Range(1, 100);
                float randPosX = rand < 51 ? Random.Range(-15f, -5f) : Random.Range(5f, 15f);
                randPos = new Vector3(transform.position.x + randPosX, transform.position.y, transform.position.z + Random.Range(-10f, 0f));
                break;
            case SpawnType.RANDOM:
                randPos = new Vector3(transform.position.x + Random.Range(-15f, 15f), transform.position.y, transform.position.z + Random.Range(-10f, 0f));
                break;
        }
        GameObject spawned = Instantiate(mummyPrefab, randPos, Quaternion.identity)as GameObject;
        spawned.transform.GetChild(0).rotation = Quaternion.Euler(0, 0, 0);
        spawned.GetComponent<MummyAgent>().target = new Vector3(spawned.transform.position.x, targetPos.y, targetPos.z);
        spawned.GetComponent<MummyMaterialColor>().SetupColor(mummyColor);
    }
}
