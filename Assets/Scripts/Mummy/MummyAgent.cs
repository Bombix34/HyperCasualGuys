using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;


public class MummyAgent : MonoBehaviour
{
    [SerializeField]
    private MummySettings settings;

    MummyState curState = MummyState.Spawn;

    NavMeshAgent agent;

    public Vector3 target;


    float timeBeforeDisappear = 2f;

    [SerializeField]
    private Transform modelTransform;
    [SerializeField]
    private GameObject modelBody;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
        agent.speed = settings.movementSpeed;
    }

    private void Start()
    {
        modelTransform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Ground")
        {
            if(curState==MummyState.Spawn)
            {
                PursuitState();
            }
        }
        else if(collision.gameObject.tag=="Trap")
        {
            if(curState!=MummyState.Ragdoll)
                RagdollState();
            Vector3 contactPos = collision.contacts[0].point;
            Vector3 trapPos = collision.transform.position;
            Vector3 forceVector = new Vector3(contactPos.x - trapPos.x, contactPos.y - trapPos.y, contactPos.z - trapPos.z).normalized;
            GetComponent<RagdollEnabler>().AddForceToRagdoll(forceVector * (settings.touchedForce));
        }
    }

    public void PursuitState()
    {
        curState = MummyState.Pursuit;
        modelTransform.rotation = Quaternion.Euler(0, 0, 0);
        agent.enabled = true;
        agent.SetDestination(target);
    }

    public void RagdollState()
    {
        curState = MummyState.Ragdoll;
        agent.enabled = false;
        modelTransform.rotation = Quaternion.Euler(0, 0, 0);
        GetComponent<RagdollEnabler>().DoRagdoll(true);
        KillMummy();
    }

    public void DoExplose(Vector3 explositionPosition)
    {
        if (curState != MummyState.Ragdoll)
            RagdollState();
        Vector3 forceVector = new Vector3(transform.position.x - explositionPosition.x, transform.position.y - explositionPosition.y, transform.position.z - explositionPosition.z).normalized;
        GetComponent<RagdollEnabler>().AddForceToRagdoll(forceVector * (settings.explosionForce));
        GetComponent<MummyMaterialColor>().SetExplodeMaterial();
    }

    private IEnumerator KillMummyCoroutine()
    {
        yield return new WaitForSeconds(timeBeforeDisappear);
        modelBody?.transform?.DOScale(0f, 1f).OnComplete(() => Destroy(this.gameObject));
    }

    public void KillMummy()
    {
        StartCoroutine(KillMummyCoroutine());
    }

    public enum MummyState 
    {
        Pursuit,
        Ragdoll,
        Spawn 
    }
}
