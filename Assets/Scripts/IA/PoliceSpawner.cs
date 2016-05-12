using UnityEngine;
using System.Collections;

public class PoliceSpawner : MonoBehaviour {

    public GameObject[] prefabPolice;
    Transform policeHolder;
	


	void Start () {
        policeHolder = GameObject.Find("Policemen").transform;
        spawnOne(0);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void spawnOne(int index)
    {
        GameObject men = (GameObject)Instantiate(prefabPolice[index], transform.position, transform.rotation);
        men.transform.parent = policeHolder;
    }
}
