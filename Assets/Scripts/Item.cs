using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
    public bool throwCourbe ;
    public float poid=1;
	void Start () {
        if (poid == 0)
            poid = 1;
	}

    public void Throw(Vector2 force)
    {
        if (!throwCourbe)
        {
            straight(force);
        }
        else
        {
            courbe(force);
        }
    }

    void straight(Vector2 f)
    {
        //GetComponent<Rigidbody>().useGravity = false;
        StartCoroutine(throwTime());
        this.GetComponent<Rigidbody>().AddForce((transform.forward * (f.x+f.y)/ poid));
    }

    void courbe(Vector2 f)
    {
        this.GetComponent<Rigidbody>().AddForce(((transform.forward * f.x) + (transform.up * f.y))/ poid);
    }

    IEnumerator throwTime()
    {
        yield return new WaitForSeconds(1);
        GetComponent<Rigidbody>().useGravity = true;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Ennemi"  )
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            //stun ennemi
        }
    }
}
