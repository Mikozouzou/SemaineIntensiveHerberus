using UnityEngine;
using System.Collections;

public class EnemyCatcher : Enemy {

    GameObject[] players;
    Transform currentTarget;
    protected override void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        currentTarget = players[0].transform;
        base.Start();
    }

    protected override void personnalBehavior()
    {
        if (currentTarget.GetComponentInParent<Stun>()&& currentTarget.GetComponentInParent<Stun>().isStun)
        {
            currentTarget = trophy;
        }
        float bestDist = Vector3.Distance(currentTarget.position, transform.position);
        Transform bestTarget = currentTarget;
        foreach (GameObject go in players)
        {
            float dist = Vector3.Distance(go.transform.position, transform.position);
            if (dist < bestDist && go.GetComponentInParent<Stun>().isStun == false)
            {
                bestTarget = go.transform;
                bestDist = dist;
            }
        }
        if (Vector3.Distance(transform.position, trophy.position) < bestDist)
        {
            bestTarget = trophy;
        }
        currentTarget = bestTarget;
        agent.SetDestination(currentTarget.position);

        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }


}
