using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Vector3 staticBasePosition;
    private Quaternion baseRotation;

    private CameraState currentState = CameraState.STATIC;

    private Transform target=null;

    public float smoothSpeedFollow = 0.125f;
    public float smoothSpeedReturnToStatic = 0.125f;

    public float rotationFollowSpeed = 5f;
    private Vector3 currentOffset;
    public Vector3 followOffset;
    public Vector3 explosionOffset;
    public Vector3 endGameOffset;

    private void Awake()
    {
        staticBasePosition = transform.position;
        baseRotation = transform.rotation;
    }

    public void FollowTarget(Transform newTarget, bool isEndGame=false)
    {
        target = newTarget;
        currentState = CameraState.FOLLOW;
        if (isEndGame)
            currentOffset = endGameOffset;
        else
            currentOffset = followOffset;
    }

    public void ReturnToStaticPosition()
    {
        currentState = CameraState.STATIC;
        target = null;
       // transform.position = staticBasePosition;
    }

    void FixedUpdate()
    {
        if (currentState == CameraState.FOLLOW)
        {
            if (target == null)
                return;
            Vector3 desiredPosition = target.position + currentOffset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeedFollow);
            transform.position = smoothedPosition;
            Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime * rotationFollowSpeed);
        }
        else if(currentState==CameraState.STATIC)
        {
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, staticBasePosition, smoothSpeedReturnToStatic);
            transform.position = smoothedPosition;
            Quaternion smoothedRotation = Quaternion.Lerp(transform.rotation, baseRotation, smoothSpeedReturnToStatic);
            transform.rotation = smoothedRotation;
        }
    }

    public void ExplodeEffect()
    {
        currentOffset = explosionOffset;
    }

    public Transform Target
    {
        get
        {
            return target;
        }
    }

    public CameraState CurrentState
    {
        get
        {
            return currentState;
        }
    }

    public bool AtInitPosition
    {
        get
        {
            bool isGoodState = currentState == CameraState.STATIC;
            bool isGoodPosition = Vector3.Distance(transform.position, staticBasePosition) < 0.4f;
            return isGoodState && isGoodPosition;
        }
    }

    public ShakeScreen ScreenShake { get => GetComponent<ShakeScreen>();}


}

public enum CameraState
{
    STATIC,
    FOLLOW
}
