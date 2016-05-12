using UnityEngine;
using System.Collections;

public class EnemyDefender : Enemy {

    GameObject[] players;
    public float trophySpeedMulti, followDistance, quitFollowDistance;
    Vector3 startFollowPos;
    public float timeFollowTrophy=1;
    float baseSpeed;
    float currentTimeFollow = 0;
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
        if (currentItem != null && hand.GetComponentInChildren<Item>())
        {
            currentTarget = policeStation;
            agent.speed = baseSpeed * trophySpeedMulti;
        }
        else if (currentTarget.tag == "Player")
        {
            if (Vector3.Distance(startFollowPos, transform.position) > quitFollowDistance || currentTarget.GetComponentInParent<Stun>().isStun)
            {
                StartCoroutine(wait());
            }
        }
        else
        {
            currentTimeFollow += updateRate;
            checkPlayer();
        }
        
       


        base.personnalBehavior();
    }

    void checkPlayer()
    {
        if (currentTimeFollow > timeFollowTrophy)
        {
            StartCoroutine(wait());
        }
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

    IEnumerator wait()
    {
        agent.Stop();
        yield return new WaitForSeconds(waitingTime);
        agent.Resume();
        currentTimeFollow = 0;
        checkPlayer();
    }

    
}
