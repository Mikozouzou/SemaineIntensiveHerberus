using UnityEngine;
using System.Collections;

public class PlayerStun : Stun {

    Movement move;
    public float invincibleTime = 1;
    public bool isInvincible=false;

    protected override void Start()
    {
        move = GetComponent<Movement>();
        base.Start();
    }

    public override void startStun(float t)
    {
        if (!isStun && !isInvincible)
        {
            stopMovement();
            base.startStun(t);
        }
    }

    void stopMovement()
    {
        move.enabled = false;
    }

    void allowMovement()
    {
        move.enabled = true;
    }

    protected override void quitStun()
    {
        StartCoroutine(invincible());
        allowMovement();
        base.quitStun();
    }
    IEnumerator invincible()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibleTime);
        isInvincible = false;
    }
}
