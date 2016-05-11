using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour {
    protected Transform policeStation;
    public Transform hand;
    protected GameObject currentItem;
    protected string targetTag = "Trophy";
    protected Transform trophy;
    protected Transform currentTarget;
    public float stunTime = 1;
    protected NavMeshAgent agent;
    public float speedTime, speedMulti;
	protected virtual void Start () {
        currentItem = null;
        policeStation = GameObject.Find("PoliceStation").transform;
        trophy = GameObject.FindGameObjectWithTag(targetTag).transform;
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating("personnalBehavior",0.5f,0.4f);
	}
	
	//void Update () {
    //  agent.SetDestination(target.position);
	//}

    protected virtual void personnalBehavior()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        if (currentTarget)
            agent.SetDestination(currentTarget.position);
    }

    protected virtual void playerHit(GameObject playerHit)
    {
        StartCoroutine(speedBuff());
        personnalBehavior();
        playerHit.GetComponentInParent<PlayerStun>().startStun(stunTime);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Player")
        {
            GameObject go = col.collider.GetComponentInParent<PlayerHand>().currentItem;
            if (go && go.tag == targetTag)
            {
                currentItem = go;
                go = null;
                // Take Trophy & stun
                takeTrophy();
            }
            playerHit(col.gameObject);
        }
        else if (col.collider.tag == targetTag)
        {
            // Take Trophy
            currentItem = col.gameObject;
            Debug.Log(col.gameObject.name);
            takeTrophy();
            personnalBehavior();
        }
    }

    IEnumerator speedBuff()
    {
        agent.speed *= speedMulti;
        yield return new WaitForSeconds(speedTime);
        agent.speed = agent.speed/speedMulti;
    }

    protected virtual void takeTrophy()
    {
        if (trophy.parent.parent.tag != "Police")
        {
            currentItem.transform.parent = hand;
            currentItem.transform.position = hand.position;
            currentItem.transform.rotation = transform.rotation;
            currentItem.GetComponentInParent<Rigidbody>().isKinematic = true;
            currentItem.GetComponentInParent<Item>().Stop();
        }
    }
}
