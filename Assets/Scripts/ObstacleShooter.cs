using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleShooter : MonoBehaviour
{

    [SerializeField]
    private TrapSpawner obstacleSpawner;

    private CameraManager cameraManager;

    [SerializeField]
    private float yPosition, zPosition;

    [SerializeField]
    private GameObject baliseDroite;

    [SerializeField]
    private GameObject baliseGauche;

    float distanceAB;


    private void Awake()
    {
        cameraManager = GetComponent<CameraManager>();
        distanceAB = Vector3.Distance(baliseGauche.transform.position, baliseDroite.transform.position);

       


      

        
    }

    private void Update()
    {
        if (!cameraManager.AtInitPosition)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            
            float ratio = Input.mousePosition.x / Screen.width;
            float realPosition = distanceAB * ratio;
            float spawnPositionX = baliseGauche.transform.position.x + realPosition;
            Vector3 spawnPosition = new Vector3(spawnPositionX, yPosition, zPosition);
            GameObject newObstacle = obstacleSpawner.SpawnTrap(spawnPosition);
            cameraManager.FollowTarget(newObstacle.transform);
            //RaycastHit hit;
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //if (Physics.Raycast(ray, out hit))
            // {
            //    float xValue = hit.point.x;
            //Vector3 spawnPosition = new Vector3(xValue, yPosition, zPosition);
            // GameObject newObstacle = obstacleSpawner.SpawnTrap(spawnPosition);
            // cameraManager.FollowTarget(newObstacle.transform);
            // }
        }

    }

}
