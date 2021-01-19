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
    [SerializeField]
    private GameObject fxPrefab;

    private bool isExplosing = false;

    private void Update()
    {
        if (isExplosing)
            return;
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
        isExplosing = true;
        //Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider hit in colliders)
        {
            if (hit.gameObject.CompareTag("Mummy"))
            {
                MummyAgent agent = hit.gameObject.GetComponent<MummyAgent>();
                agent.DoExplose(transform.position);
            }
        }
        StartCoroutine(WaitForEndExplosion());
    }

    private IEnumerator WaitForEndExplosion()
    {
        GameObject fx = Instantiate(fxPrefab, null);
        fx.transform.position = this.transform.position;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        CameraManager camManager = Camera.main.GetComponent<CameraManager>();
        camManager.ScreenShake.setShake(0.2f);
        if(GameManager.Instance.IsCameraFollowProjectile)
            camManager.ExplodeEffect();
        yield return new WaitForSeconds(0.5f);
        camManager.ReturnToStaticPosition();
        Destroy(this.gameObject);
    }
}
