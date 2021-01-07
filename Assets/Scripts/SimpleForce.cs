using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleForce : MonoBehaviour
{
    [SerializeField]
    private Obstacle settings;

    Rigidbody body;

    Vector3 initPos;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
        initPos = gameObject.transform.position;
    }

    public void AddForce()
    {
        transform.position = initPos;
        body.velocity /= 10;
        body.AddForce(new Vector3(0f, -4f, 10f) * Random.Range(settings.minSpeed,settings.maxSpeed)*100f,ForceMode.Impulse);
    }

}
