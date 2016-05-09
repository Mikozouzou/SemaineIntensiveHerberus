using UnityEngine;
using System.Collections;

public class PlayerLife : Destroyable
{

    public override void GetDamage(int dmg)
    {
        life -= dmg;
        if (life <= 0)
        {
            death();
        }
    }

    void death()
    {
        Rigidbody rgd = GetComponent<Rigidbody>();
        GetComponent<Movement>().enabled = false;
        GetComponent<PlayerHand>().enabled = false;
        rgd.constraints = RigidbodyConstraints.None;
        
        rgd.AddForce(transform.position + transform.forward);
        Invoke("kin", 2f);
    }
}
