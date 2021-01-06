using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "HyperCasualGuys/new Obstacle Settings")]
public class Obstacle : ScriptableObject
{
    public GameObject objectPrefab;
    public float minSize;
    public float maxSize;
    public float minSpeed;
    public float maxSpeed;
}
