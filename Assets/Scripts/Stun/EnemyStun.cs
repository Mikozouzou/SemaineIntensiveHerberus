using UnityEngine;
using System.Collections;

public class EnemyStun : Stun
{
    NavMeshAgent agent;
    public float bumpLenght = 5;
    Enemy scriptMovement;

    protected override void Start () {
        agent = GetComponent<NavMeshAgent>();
        scriptMovement = GetComponent<Enemy>();
        base.Start();
    }

    public override void startStun(float t)
    {
        if (!isStun)
        {
            stopMovement();
        }
        base.startStun(t);
    }

    void stopMovement()
    {
        if(anim ==null)
            anim = GetComponent<Enemy>().anim;
        if(anim)
        anim.Play("anim_policiers_Stunned");
        agent.Stop();
        scriptMovement.dropItem();
        scriptMovement.enabled = false;
    }

    void allowMovement()
    {
        scriptMovement.enabled = true;
        agent.Resume();
        if (anim)
            anim.Play("anim_policiers_Run");
    }

    protected override void quitStun()
    {
        allowMovement();
        base.quitStun();
    }

    public IEnumerator bumpBack(Vector3 pos, float force =1)
    {
        Vector3 dir = transform.position-pos  ;
        for (int i = 0; i < bumpLenght; i++)
        {
            transform.position = transform.position +(dir.normalized * force * Time.deltaTime);
            yield return 1;
        }
    }
}
