using UnityEngine;
using System.Collections;

public class EnemyAttacker : Enemy {

    GameObject[] players;
    public float xTime, zTime, viewDistance;

    protected override void Start()
    {
        
        players = GameObject.FindGameObjectsWithTag("Player");
        currentTarget = players[0].transform;
        getRandomTarget();
        base.Start();
    }

    protected override void personnalBehavior()
    {
        if (currentItem != null && trophy.GetComponentInParent<EnemyStun>())
        {
            currentTarget = policeStation;
        }
        else if (currentTarget != trophy)
        {
            currentItem = null;
            if (Vector3.Distance(trophy.position, transform.position) <= viewDistance)
            {
                followTrophy();
            }
            else
            {
                foreach (GameObject player in players)
                {
                    if (Vector3.Distance(player.transform.position, transform.position) <= viewDistance && !player.GetComponentInParent<Stun>().isStun)
                    {
                        StopAllCoroutines();
                        currentTarget = player.transform;
                        StartCoroutine(cooldown(zTime));
                        break;
                    }
                }
            }
        }
        base.personnalBehavior();
    }

    protected override void playerHit(GameObject playerHit)
    {
        StopCoroutine("cooldown");
        getRandomTarget();
        base.playerHit(playerHit);
    }

    void followTrophy()
    {
        StopCoroutine("cooldown");
        currentTarget = trophy;
        StartCoroutine(cooldown(zTime * 1.5f));
    }

    void getRandomTarget()
    {
        currentTarget = players[Random.Range(0, players.Length)].transform;
        if (currentTarget.GetComponentInParent<Stun>().isStun)
        {
            foreach (GameObject player in players)
            {
                if (!player.GetComponentInParent<Stun>().isStun)
                {
                    currentTarget = player.transform;
                    break;
                }
                else
                {
                   currentTarget = trophy;
                }
            }
        }
        
        
        StartCoroutine(cooldown(xTime));
    }

    IEnumerator cooldown(float t)
    {
        yield return new WaitForSeconds(t);
        getRandomTarget();
    }
}
