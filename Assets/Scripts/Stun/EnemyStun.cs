using UnityEngine;
using System.Collections;

public class EnemyStun : Stun
{
    NavMeshAgent agent;
<<<<<<< HEAD
    

=======
    public float bumpLenght = 5;
>>>>>>> refs/remotes/origin/Will
    protected override void Start () {
        agent = GetComponent<NavMeshAgent>();
        base.Start();
    }

    public override void startStun(float t)
    {
        if (!isStun)
        {
            stopMovement();
        }

        base.startStun(t);
    }

    void stopMovement()
    {
        agent.Stop();
    }

    void allowMovement()
    {
        agent.Resume();

    }

    protected override void quitStun()
    {
        allowMovement();
        base.quitStun();
    }

<<<<<<< HEAD
=======
    public IEnumerator bumpBack(Vector3 pos, float force =1)
    {
        GetComponent<NavMeshAgent>().Stop();
        Vector3 dir = transform.position-pos  ;
        for (int i = 0; i < bumpLenght; i++)
        {
            
            transform.position = transform.position +(dir.normalized * force * Time.deltaTime);
            yield return 1;
        }
        GetComponent<NavMeshAgent>().Resume();
    }

    
>>>>>>> refs/remotes/origin/Will
}
