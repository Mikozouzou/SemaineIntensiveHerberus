using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour {
    protected string targetTag = "Trophy";
    protected Transform trophy;
    public float stunTime = 1;
    protected NavMeshAgent agent;

	protected virtual void Start () {
        trophy = GameObject.FindGameObjectWithTag(targetTag).transform;
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating("personnalBehavior",0.5f,0.1f);
	}
	
	//void Update () {
 //       agent.SetDestination(target.position);
	//}

    protected abstract void personnalBehavior();

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Player")
        {
            GameObject go = col.collider.GetComponentInParent<PlayerHand>().currentItem;
            if (go && go.tag == targetTag)
            {
                // Player lost
                Debug.Log("Lost");
            }
            else
            {
                // player stun
                col.collider.GetComponentInParent<PlayerStun>().startStun(stunTime);
                personnalBehavior();
            }
        }
        else if (col.collider.tag == targetTag)
        {
            // player lost
        }
    }
}
