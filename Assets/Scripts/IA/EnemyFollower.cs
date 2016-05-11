using UnityEngine;
using System.Collections;

public class EnemyFollower : Enemy {

	

    protected override void personnalBehavior()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        if (agent != null && trophy != null)
            agent.SetDestination(trophy.position);
    }
}
