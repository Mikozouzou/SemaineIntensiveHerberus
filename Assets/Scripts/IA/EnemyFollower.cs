using UnityEngine;
using System.Collections;

public class EnemyFollower : Enemy {

	

    protected override void personnalBehavior()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        agent.SetDestination(trophy.position);
    }
}
