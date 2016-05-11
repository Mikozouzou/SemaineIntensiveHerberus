using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    public int playerID;
    public float speed;
	[HideInInspector]
	public float originalSpeed;
    public int rotateSpeed;
    public Vector3 direction;
    public float aimX;
    public float aimY;
    PlayerHand hand;
    // Use this for initialization
<<<<<<< HEAD
    void Start () 
	{
		originalSpeed = speed;
=======
    void Start () {
        hand = GetComponent<PlayerHand>();
>>>>>>> refs/remotes/origin/master
	}
	
	

	void Update () {
        if (Input.GetKeyDown(KeyCode.C))
        {
            GetComponent<PlayerStun>().startStun(1);
        }

        float stickX = XInput.instance.getLeftXStick(playerID);
        float stickY = XInput.instance.getLeftYStick(playerID);
        if (Input.GetKey(KeyCode.Z))
        {
            stickY = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            stickY = -1;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            stickX = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            stickX = 1;
        }

        direction.x = stickX;
        direction.z = stickY;
        
        aimX = XInput.instance.getRightXStick(playerID);
        aimY = XInput.instance.getRightYStick(playerID);
        if (aimX !=0 || aimY !=0)// (GetComponent<PlayerHand>().current.improvedAIM)
        {
            
            if (aimX > 0.2f || aimX < -0.2f || aimY > 0.2f || aimY < -0.2f)
            {
                Vector3 look = new Vector3(aimX + transform.position.x, transform.position.y, aimY + transform.position.z);
                transform.LookAt(look);
            }
            
        }
        else
        {
            Vector3 look = new Vector3(stickX + transform.position.x, transform.position.y, stickY + transform.position.z);
            transform.LookAt(look);
        }

        if (stickY != 0 || stickX != 0)
        {
            move();      
        }

        
    }

    void move()
    {        
        direction = direction.normalized;
        transform.position = transform.position + direction * (speed / hand.poids) * Time.deltaTime;
    }
}
