﻿using UnityEngine;
using System.Collections;

public class EnemyStun : Stun
{
    NavMeshAgent agent;
    public float bumpLenght = 5;
    public float bumpForce = 1;
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

    public IEnumerator bumpBack(Vector3 pos)
    {
        GetComponent<NavMeshAgent>().Stop();
        Vector3 dir = transform.position-pos  ;
        for (int i = 0; i < bumpLenght; i++)
        {
            
            transform.position = transform.position +(dir.normalized *bumpForce*Time.deltaTime);
            yield return 1;
        }
        GetComponent<NavMeshAgent>().Resume();
    }

    
}
