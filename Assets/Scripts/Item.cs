using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
    public bool throwCourbe ;
    [Range(0.1f, 1.5f)]
    public float velocityMulti= 0.98f;
    Vector3 velocity;
    bool isFlying;
    Rigidbody rigid;
    public float stunTime = 1;
    public int CompteurPasse = 0;
	void Start () {
        rigid = GetComponent<Rigidbody>();
	}

    void Update()
    {
        if (isFlying)
        {
            transform.position += velocity*Time.deltaTime;
            velocity *= velocityMulti;
        }
    }

    public void Throw(float force)
    {
        isFlying = true;
        CompteurPasse++;
        if (throwCourbe)
        {
            velocity = new Vector3(transform.forward.x, transform.up.y/2, transform.forward.z)*force;
        }
        else
        {
            velocity = transform.forward * force;
        }
    }
    

    //void straightRigid(Vector2 f)
    //{
    //    rigid.AddForce((transform.forward * (f.x*2+f.y)));
    //}

    //void courbeRigid(Vector2 f)
    //{
    //    rigid.AddForce(((transform.forward * f.x) + (transform.up * f.y)));
    //}
    

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Enemy" && !rigid.isKinematic)
        {
            rigid.velocity = Vector3.zero;
            col.collider.GetComponent<Stun>().startStun(stunTime);
        }
        else if (col.collider.tag == "Ground")
        {
            rigid.isKinematic = true;
            CompteurPasse = 0;
        }
        Stop();
    }

    public void Stop()
    {
        isFlying = false;
        velocity = Vector3.zero;
    }
}
