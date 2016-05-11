using UnityEngine;
using System.Collections;

public class EnemyDefender : Enemy {

    GameObject[] players;
    public float xTime, zTime, followDistance, quitFollowDistance;

    protected override void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        
        base.Start();
    }

    protected override void personnalBehavior()
    {
        if (currentItem != null && trophy.GetComponentInParent<EnemyStun>())
        {
            Debug.Log(trophy.parent.parent.parent.tag);
            currentTarget = policeStation;

        }
        else if (currentTarget.tag == "Player")
        {
            if (Vector3.Distance(currentTarget.transform.position, transform.position) > quitFollowDistance)
            {
                checkPlayer();
            }
        }
        else
        {
            currentTarget = trophy;
            checkPlayer();
        }
        base.personnalBehavior();
    }

    void checkPlayer()
    {
        foreach (GameObject player in players)
        {
            if (Vector3.Distance(player.transform.position, transform.position) < followDistance)
            {
                currentTarget = player.transform;
            }
        }
    }

    protected override void playerHit(GameObject playerHit)
    {
        StopCoroutine("cooldown");

        base.playerHit(playerHit);
    }
    

    IEnumerator cooldown(float t)
    {
        yield return new WaitForSeconds(t);
        
    }
}
