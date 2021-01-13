using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleShooter : MonoBehaviour
{
    private bool canShoot = true;
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
        if (!cameraManager.AtInitPosition || !canShoot)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            canShoot = false;
            float ratio = Input.mousePosition.x / Screen.width;
            float realPosition = distanceAB * ratio;
            float spawnPositionX = baliseGauche.transform.position.x + realPosition;
            Vector3 spawnPosition = new Vector3(spawnPositionX, yPosition, zPosition);
            GameObject newObstacle = obstacleSpawner.SpawnTrap(spawnPosition);
            StartCoroutine(CameraFollowCoroutine(newObstacle));
        }
    }

    private IEnumerator CameraFollowCoroutine(GameObject newObstacle)
    {
        yield return new WaitForSeconds(0.15f);
        cameraManager.FollowTarget(newObstacle.transform);
        canShoot = true;
    }

}
