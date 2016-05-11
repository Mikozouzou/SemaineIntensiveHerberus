using UnityEngine;
using System.Collections;

public class PlayerHand : MonoBehaviour {
    int playerID;
    public Transform hand;
    Transform trophy;
    public GameObject currentItem;
    public float throwForce;
    bool seekItem = false;
    [HideInInspector]
    public float poids;
    public bool canTake = true;
    public bool canThrow = false;
    void Start () {
        poids = 1;
        playerID = GetComponent<Movement>().playerID;
        trophy = GameObject.FindGameObjectWithTag("Trophy").transform;
    }
	
	void Update ()
    {
        if (currentItem&&!currentItem.GetComponentInParent<PlayerStun>())
        {
            poids = 1;
            currentItem = null;
            canThrow = false;
            StartCoroutine(reloadTake(0.5f));
        }

        float trigger = XInput.instance.getTriggerRight(playerID);

        if (currentItem&& canThrow && trigger > 0.8f || Input.GetKey(KeyCode.A))
        {
            throwItem();
        }

        //if (!currentItem && (XInput.instance.getButton(playerID, 'A') == XInputDotNetPure.ButtonState.Pressed || Input.GetKey(KeyCode.A)))
        //{
        //    checkTrophy();
        //}
        if (!currentItem && canTake&& trigger > 0.8f || Input.GetKey(KeyCode.A))
        {
            canThrow = false;
            checkTrophy();
        }
        else
        {
            seekItem = false;
        }

        
        
    }

    void OnTriggerStay(Collider col)
    {
        if (seekItem && col.GetComponentInParent<Item>() && col.transform.parent.tag != "Player")
        {
            seekItem = false;
            currentItem = col.transform.parent.gameObject;
            takeItem();
        }
    }

    void checkTrophy()
    {
        if (Vector3.Distance(trophy.position,transform.position) <= 2.5f && trophy.parent.tag != "Player")
        {
            currentItem = trophy.parent.gameObject;
            takeItem();
        }
        else
        {
            seekItem = true;
        }
    }

    public void throwItem()
    {
        
        if (currentItem == null)
            return;
        if (!currentItem.GetComponentInParent<PlayerStun>())
        {
            currentItem = null;
            return;
        }
        canThrow = false;
        StartCoroutine(reloadTake(0.5f));

        currentItem.GetComponent<Rigidbody>().isKinematic = false;
        currentItem.GetComponent<Item>().Throw(throwForce);
        poids = 1;
        currentItem.transform.parent = GameObject.Find("ThrowingProps").transform;
        currentItem = null;
    }
    
    void takeItem()
    {
        StartCoroutine(reloadThrow(0.2f));
        canTake = false;
        currentItem.transform.parent = hand;
		currentItem.transform.position = hand.position;
        currentItem.transform.rotation = transform.rotation;
        currentItem.GetComponent<Rigidbody>().isKinematic =true;
        currentItem.GetComponent<Item>().Stop();
        poids = currentItem.GetComponent<Item>().poids;
    }

    IEnumerator reloadTake(float t)
    {
        yield return new WaitForSeconds(t);
        canTake = true;
    }

    IEnumerator reloadThrow(float t)
    {
        yield return new WaitForSeconds(t);
        canThrow = true;
    }
}
