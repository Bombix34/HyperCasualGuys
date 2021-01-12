using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "HyperCasualGuys/Mummy Settings")]
public class MummySettings : ScriptableObject
{
    public float movementSpeed = 1f;

    public float touchedForce = 1f;
    public float explosionForce = 1f;
}
