using UnityEngine;
using System.Collections;

public class EnemyStun : Stun
{
    NavMeshAgent agent;
    

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

}
