using UnityEngine;
using System.Collections;

public class EnemyDefender : Enemy {

    GameObject[] players;
    public float trophySpeedMulti, followDistance, quitFollowDistance;
    Vector3 startFollowPos;
    float baseSpeed;
    protected override void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        
        base.Start();
        currentTarget = trophy;
        baseSpeed = agent.speed;
    }

    protected override void personnalBehavior()
    {
        agent.speed = baseSpeed;
        if (currentItem != null && trophy.GetComponentInParent<EnemyStun>())
        {
            currentTarget = policeStation;
            agent.speed = baseSpeed * trophySpeedMulti;
        }
        else if (currentTarget.tag == "Player")
        {
            if (Vector3.Distance(startFollowPos, transform.position) > quitFollowDistance || currentTarget.GetComponentInParent<Stun>().isStun)
            {
                checkPlayer();
            }
        }
        else
        {
            checkPlayer();
        }
        base.personnalBehavior();
    }

    void checkPlayer()
    {
        currentTarget = trophy;
        startFollowPos = Vector3.zero;
        foreach (GameObject player in players)
        {
            if (Vector3.Distance(player.transform.position, transform.position) < followDistance && !player.GetComponentInParent<Stun>().isStun)
            {
                currentTarget = player.transform;
                startFollowPos = transform.position;
            }
        }
    }

   

    
}
