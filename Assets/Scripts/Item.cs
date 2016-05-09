using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
    public bool throwCourbe ;
    public float poid=1;

    Rigidbody rigid;

	void Start () {
        if (poid == 0)
            poid = 1;
        rigid = GetComponent<Rigidbody>();
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
        rigid.AddForce((transform.forward * (f.x*2+f.y)/ poid));
    }

    void courbe(Vector2 f)
    {
        rigid.AddForce(((transform.forward * f.x) + (transform.up * f.y))/ poid);
    }
    

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Enemy" && !rigid.isKinematic)
        {
            rigid.velocity = Vector3.zero;

            //stun ennemi
        }
        else if (col.collider.tag == "Ground")
        {
            rigid.isKinematic = true;
        }
    }
}
