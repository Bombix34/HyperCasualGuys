using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private float radius;
    [SerializeField]
    private float power;
   
    
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CameraManager camera = Camera.main.GetComponent<CameraManager>();
            if (camera.CurrentState == CameraState.FOLLOW)
            {
                FruitExplosion();
            }

        }
    }
    private void FruitExplosion()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {

            if (hit.gameObject.CompareTag("Mummy"))
            {
                Debug.Log("Passé dans le comparetag");
                MummyAgent agent = hit.gameObject.GetComponent<MummyAgent>();
                agent.RagdollState();
                agent.GetComponent<Rigidbody>().AddExplosionForce(power, explosionPos, radius, 3.0f);
            }
        }

        Destroy(gameObject, 0.3f);
    }
}
