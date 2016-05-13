using UnityEngine;
using System.Collections;

public abstract class Stun : MonoBehaviour {

    Rigidbody rigid;
    protected Animation anim;
    public bool isStun = false;
    AudioSource audioS;
    AudioClip sonStun;

    protected virtual void Start()
    {
        audioS = this.gameObject.AddComponent<AudioSource>();
        rigid = GetComponent<Rigidbody>();
        sonStun = (AudioClip) Resources.Load("Stun");
        audioS.clip = sonStun;

    }



    public virtual void startStun(float t)
    {
        if (!isStun)
        {
            audioS.Play();

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
        audioS.Stop();
        if (rigid)
            rigid.isKinematic = false;
        isStun = false;
    }

}
