using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoliceManager : MonoBehaviour {

    //Dictionary<GameObject, Transform> squad;
    public List<GameObject> squad;

	void Start () {
        squad = new List<GameObject>(GameObject.FindGameObjectsWithTag("Police"));
    }
	
	
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (squad.Contains(col.transform.parent.gameObject) &&col.gameObject.GetComponentInChildren<Item>() && col.gameObject.GetComponentInChildren<Item>().gameObject.tag == "Trophy")
        {
            // Players Loose
            Debug.Log("Police Win");
        }
    }
}
