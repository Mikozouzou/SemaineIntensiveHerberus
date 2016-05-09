using UnityEngine;
using System.Collections;

public class PlayerHand : MonoBehaviour {
    int playerID;
    public Transform hand;
    public GameObject currentItem;
    public Vector2 force;
	void Start () {
        playerID = GetComponent<Movement>().playerID;
    }
	
	void Update ()
    {
        if (currentItem && XInput.instance.getTriggerRight(playerID) > 0.8f || Input.GetKeyDown(KeyCode.E))
        {
            throwItem();
        }

        if ((XInput.instance.getTriggerRight(playerID) >0.8f ||(playerID == 1 && Input.GetKeyDown(KeyCode.O))) && currentItem)
        {
            if (currentItem)
            {

            }
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (!currentItem && (XInput.instance.getButton(playerID, 'A')==XInputDotNetPure.ButtonState.Pressed || Input.GetKey(KeyCode.A)))
        {
            if (col.GetComponent<Item>())
            {
                currentItem = col.gameObject;
                takeItem();
            }
        }
    }

    public void throwItem()
    {
        if (currentItem == null)
            return;
        currentItem.GetComponent<Rigidbody>().isKinematic = false;
        currentItem.GetComponent<Item>().Throw(force);


        // Throw with rigidbody
        //currentItem.GetComponent<Rigidbody>().AddForce((transform.forward * force.x) +(transform.up* force.y));

        currentItem.transform.parent = null;
        currentItem = null;
    }



    void takeItem()
    {
        currentItem.transform.parent = hand;
        currentItem.transform.position = hand.position;
        currentItem.transform.rotation = transform.rotation;
        currentItem.GetComponent<Rigidbody>().isKinematic =true;
    }

    IEnumerator reload(float t)
    {
        yield return new WaitForSeconds(t);
    }
}
