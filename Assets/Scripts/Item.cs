using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
    public bool throwCourbe;
    public float speed = 1;
    [HideInInspector]
    public float velocityMulti= 0.98f;
    Vector3 velocity;
    bool isFlying;
    Rigidbody rigid;
    public float stunTime = 1;
    public int CompteurPasse = 0;
    public float poids = 1;


	void Start () {
        if (poids == 0)
            poids = 1;
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isFlying)
        {
            transform.position += velocity * speed * Time.deltaTime;
            if (gameObject.name == "MoneyBag")
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
        if (gameObject.name == "MoneyBag")
        {
            //transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(0).GetComponent<ParticleSystem>().Play();
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
        if (col.collider.tag == "Enemy" && isFlying)
        {
            rigid.velocity = Vector3.zero;
            col.collider.GetComponentInParent<Stun>().startStun(stunTime);
            StartCoroutine(col.collider.GetComponentInParent<EnemyStun>().bumpBack(transform.position));
        }
        else if (col.collider.tag == "Ground")
        {
            GetComponent<Rigidbody>().isKinematic = true;
            CompteurPasse = 0;
        }
        Stop();
    }

    public void Stop()
    {
        if (gameObject.name == "MoneyBag" && isFlying)
        {
            transform.GetChild(0).GetComponent<ParticleSystem>().Stop();
            transform.GetChild(1).GetComponent<ParticleSystem>().Play();
        }
        isFlying = false;
        velocity = Vector3.zero;
    }
}
