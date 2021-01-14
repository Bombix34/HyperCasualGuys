using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeScreen : MonoBehaviour
{
    private float decreaseFactor = 1.0f;
    private float shake = 0f;
    private float shakeAmount = 0.8f;
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = this.GetComponent<Camera>();
    }

    private void Update()
    {
        if (shake > 0)
        {
            mainCamera.transform.position = Random.insideUnitSphere * shakeAmount + this.transform.position;
            shake -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shake = 0.0f;
        }
    }

    public void setShake(float value)
    {
        shake = value;
    }
}
