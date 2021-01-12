﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleShooter : MonoBehaviour
{
    [SerializeField]
    private TrapSpawner obstacleSpawner;

    private CameraManager cameraManager;

    [SerializeField]
    private float yPosition, zPosition;

    private void Awake()
    {
        cameraManager = GetComponent<CameraManager>();

    }

    private void Update()
    {
        if (!cameraManager.AtInitPosition)
            return;
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                float xValue = hit.point.x;
                Vector3 spawnPosition = new Vector3(xValue, yPosition, zPosition);
                GameObject newObstacle = obstacleSpawner.SpawnTrap(spawnPosition);
                cameraManager.FollowTarget(newObstacle.transform);
            }
        }

    }
}
