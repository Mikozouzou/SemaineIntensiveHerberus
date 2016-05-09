using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
    public bool throwCourbe ;

	void Start () {
	
	}

    public void Throw(Vector2 force)
    {
        if (!throwCourbe)
        {
            straight(force.x);
        }
        else
        {
            courbe(force);
        }
    }

    void straight(float f)
    {
        this.GetComponent<Rigidbody>().AddForce((transform.forward * f));
    }

    void courbe(Vector2 f)
    {
        this.GetComponent<Rigidbody>().AddForce((transform.forward * f.x) + (transform.up * f.y));
    }
}
