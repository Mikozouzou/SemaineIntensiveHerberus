using UnityEngine;
using System.Collections;

public class SpotTop : MonoBehaviour {
    public Transform trophy;
	// Use this for initialization
	void Start () {
        trophy = GameObject.FindGameObjectWithTag("Trophy").transform;
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(trophy);
	}
}
