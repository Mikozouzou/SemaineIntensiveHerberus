using UnityEngine;
using System.Collections;

public class SpotTop : MonoBehaviour {
    public Transform target;
	// Use this for initialization
	void Start () {
        if(target==null)
        target = GameObject.FindGameObjectWithTag("Trophy").transform;
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(target);
	}
}
