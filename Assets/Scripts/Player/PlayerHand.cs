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

	void Start () {
        poids = 1;
        playerID = GetComponent<Movement>().playerID;
        trophy = GameObject.FindGameObjectWithTag("Trophy").transform;
    }
	
	void Update ()
    {
        if (currentItem&&!currentItem.GetComponentInParent<PlayerStun>())
        {
            currentItem = null;
        }
        if (!currentItem && (XInput.instance.getButton(playerID, 'A') == XInputDotNetPure.ButtonState.Pressed || Input.GetKey(KeyCode.A)))
        {
            checkTrophy();
        }
        else
        {
            seekItem = false;
        }

        if (currentItem && XInput.instance.getTriggerRight(playerID) > 0.8f || Input.GetKeyDown(KeyCode.E))
        {
            throwItem();
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
            currentItem = trophy.gameObject;
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
        currentItem.GetComponent<Rigidbody>().isKinematic = false;
        currentItem.GetComponent<Item>().Throw(throwForce);
        poids = 1;
        currentItem.transform.parent = GameObject.Find("ThrowingProps").transform;
        currentItem = null;
    }
    
    void takeItem()
    {
        currentItem.transform.parent = hand;
		currentItem.transform.position = hand.position;
        currentItem.transform.rotation = transform.rotation;
        currentItem.GetComponent<Rigidbody>().isKinematic =true;
        currentItem.GetComponent<Item>().Stop();
        poids = currentItem.GetComponent<Item>().poids;
    }

    IEnumerator reload(float t)
    {
        yield return new WaitForSeconds(t);
    }
}
