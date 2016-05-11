using UnityEngine;
using System.Collections;

public class EnemyHand : MonoBehaviour {
    
    Transform trophy;
    public GameObject currentItem;

	void Start () {
        trophy = GameObject.FindGameObjectWithTag("Trophy").transform;
    }
	
	void Update ()
    {
        
    }
    
    
}
