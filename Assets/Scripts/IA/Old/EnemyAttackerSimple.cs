using UnityEngine;
using System.Collections;

public class EnemyAttackerSimple : Enemy {

    GameObject[] players;

    protected override void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        currentTarget = players[0].transform;
        base.Start();
    }

    protected override void personnalBehavior()
    {
        if (currentItem != null && hand.GetComponentInChildren<Item>())
        {
            StopAllCoroutines();
            currentTarget = policeStation;
        }
        else
        {
            getCloseTarget();
            currentItem = null;
        }
        
        base.personnalBehavior();
    }

    protected override void playerHit(GameObject playerHit)
    {
        getCloseTarget();
        base.playerHit(playerHit);
    }

    void getCloseTarget()
    {
        float dist = Vector3.Distance(trophy.position, transform.position);
        currentTarget = trophy;
        foreach (GameObject player in players)
        {
            float distPlayer = Vector3.Distance(player.transform.position, transform.position);
            if (!player.GetComponentInParent<Stun>().isStun && distPlayer < dist)
            {
                dist = distPlayer;
                currentTarget = player.transform;
            }
        }
    }
    
    
}
