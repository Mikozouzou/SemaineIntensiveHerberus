using UnityEngine;
using System.Collections;

public class Stun : MonoBehaviour {

    Rigidbody rigid;
    NavMeshAgent agent;
    bool isStun = false;
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    
    
    public void startStun(float t)
    {
        if (!isStun)
        {
            isStun = true;
            if (rigid)
                rigid.isKinematic = true;
            if (agent)
                agent.Stop();
            StartCoroutine(delay(t));
        }
    }

    IEnumerator delay(float t)
    {
        yield return new WaitForSeconds(t);
        quitStun();
    }

    void quitStun()
    {
        if (rigid)
            rigid.isKinematic = false;
        if (agent)
            agent.Resume();
        isStun = false;
    }

}
