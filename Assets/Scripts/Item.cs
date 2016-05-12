using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
    public bool throwCourbe;
    public float throwForce = 40;
    Vector3 velocity;
    bool isFlying;
    Rigidbody rigid;
    public float stunTime = 1;
    public int CompteurPasse = 0;
    public float poids = 1;
    public float offsetHolding = 0;
    public float knockbackForce;
    [HideInInspector]
    public float onGroundForce = 1000;
    GameObject impact ;
    //public AnimationCurve curve;

    void Start () {
        if (poids == 0)
            poids = 1;
        rigid = GetComponent<Rigidbody>();
        
        impact = (GameObject) Resources.Load("PS_ImpactProp");
    }

    void Update()
    {
        if (isFlying)
        {
            if (throwCourbe)
            {
                transform.position += velocity * Time.deltaTime;
                velocity *= throwForce;
            }
        }
    }

    public void Throw(float force)
    {
        isFlying = true;
        CompteurPasse++;
        StartCoroutine(reloadLayer());
        if (throwCourbe)
        {
            velocity = new Vector3(transform.forward.x, transform.up.y/2, transform.forward.z)*force;
        }
        else
        {
            rigid.AddForce((transform.forward * force * throwForce));
        }
        if (gameObject.name == "MoneyBag")
        {
            //transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        }
        
    }

    IEnumerator reloadLayer()
    {
        GetComponentInChildren<Collider>().gameObject.layer = 9;
        yield return new WaitForSeconds(2);
        GetComponentInChildren<Collider>().gameObject.layer = 0;
    }

    //public void Throw(float force)
    //{
    //    isFlying = true;
    //    if (throwCourbe)
    //    {
    //        rigid.AddForce((transform.forward+transform.up*2) * force *50);
    //    }
    //    else
    //    {
    //        rigid.AddForce((transform.forward * force * 50));
    //    }
      
    //}

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
        //GameObject imp = (GameObject)
        if(isFlying)
        Instantiate(impact, col.contacts[0].point, impact.transform.rotation);

        if (col.collider.tag == "Enemy" && isFlying)
        {
            rigid.velocity = Vector3.zero;
            col.collider.GetComponentInParent<Stun>().startStun(stunTime);
            StartCoroutine(col.collider.GetComponentInParent<EnemyStun>().bumpBack(transform.position, knockbackForce));
        }
        else if (col.collider.tag == "Ground")
        {
            //GetComponent<Rigidbody>().isKinematic = true;
            CompteurPasse = 0;
            if (throwCourbe)
            {
                rigid.AddForce(velocity * onGroundForce);
            }
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
