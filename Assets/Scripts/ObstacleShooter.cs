using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleShooter : MonoBehaviour
{
    [SerializeField]
    private TrapSpawner obstacleSpawner;

    [SerializeField]
    private float yPosition, zPosition;
    
    void Update()
    {   
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                float xValue = hit.point.x;
                Vector3 spawnPosition = new Vector3(xValue, yPosition, zPosition);
                obstacleSpawner.SpawnTrap(spawnPosition);

                // Do something with the object that was hit by the raycast.
            }
            /*
            float ratio = Input.mousePosition.x / Screen.width;
            float xValue=0f;
            if(ratio<0.5)
            {
                xValue = -ratio * 15f;
            }
            else
            {
                xValue = ratio * 15f;
            }
            Vector3 spawnPosition = new Vector3(xValue, yPosition, zPosition);
            obstacleSpawner.SpawnTrap(spawnPosition);
            */
        }

    }
}
