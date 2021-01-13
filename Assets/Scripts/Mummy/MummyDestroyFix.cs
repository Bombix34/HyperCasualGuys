using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyDestroyFix : MonoBehaviour
{
    [SerializeField]
    private GameObject body, bones;

    void Update()
    {
        if(body==null || bones == null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            float distance = Vector3.Distance(this.transform.position, body.transform.position);
            if (distance >= 10f)
                Destroy(this.gameObject);
        }
    }
}
