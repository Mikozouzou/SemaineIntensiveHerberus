using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoliceStation : MonoBehaviour {
    public static PoliceStation instance;
    //Dictionary<GameObject, Transform> squad;
    public List<GameObject> squad;
    void Awake()
    {
        instance = this;
    }

	void Start () {
        squad = new List<GameObject>(GameObject.FindGameObjectsWithTag("Police"));
        
    }
	
	
	void Update () {
	
	}

    public void AddOnePolice(GameObject go)
    {
        squad.Add(go);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponentInParent<Enemy>()&&squad.Contains(col.GetComponentInParent<Enemy>().gameObject) &&col.gameObject.GetComponentInChildren<Item>())
        {
            // Players Loose
            Debug.Log("Police Win");
            GameManager.instance.EndTheGame(false);
        }
    }
}
