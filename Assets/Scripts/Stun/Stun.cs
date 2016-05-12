using UnityEngine;
using System.Collections;

public abstract class Stun : MonoBehaviour {

    Rigidbody rigid;
    protected Animation anim;
    public bool isStun = false;

    protected virtual void Start()
    {
        rigid = GetComponent<Rigidbody>();
        
    }



    public virtual void startStun(float t)
    {
        if (!isStun)
        {
            isStun = true;
            if (rigid)
                rigid.isKinematic = true;
            StartCoroutine(delay(t));
        }
    }

    IEnumerator delay(float t)
    {
        yield return new WaitForSeconds(t);
        quitStun();
    }

    protected virtual void quitStun()
    {
        if (rigid)
            rigid.isKinematic = false;
        isStun = false;
    }

}
