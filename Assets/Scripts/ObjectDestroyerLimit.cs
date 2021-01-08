using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyerLimit : MonoBehaviour
{
    [SerializeField]
    private bool onEnterTrigger;

    [SerializeField]
    private bool canDestroyProjectile = false;


    private CameraManager cameraManager;

    private void Awake()
    {
        cameraManager = Camera.main.GetComponent<CameraManager>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (!onEnterTrigger)
            return;
        if (other.gameObject.tag == "Trap")
        {
            if (!canDestroyProjectile)
                return;
            if(cameraManager.Target.gameObject == other.gameObject)
            {
                cameraManager.ReturnToStaticPosition();
            }
        }
        Destroy(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (onEnterTrigger)
            return;
        if (other.gameObject.tag == "Trap")
        {
            if (!canDestroyProjectile)
                return;
            if (cameraManager.Target.gameObject == other.gameObject)
            {
                Debug.Log("OUI");
                cameraManager.ReturnToStaticPosition();
            }
        }
        Destroy(other.gameObject);
    }
}
