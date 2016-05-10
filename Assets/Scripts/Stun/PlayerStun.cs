using UnityEngine;
using System.Collections;

public class PlayerStun : Stun {

    Movement move;

    protected override void Start()
    {
        move = GetComponent<Movement>();
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
        move.enabled = false;
    }

    void allowMovement()
    {
        move.enabled = true;
    }

    protected override void quitStun()
    {
        allowMovement();
        base.quitStun();
    }
}
