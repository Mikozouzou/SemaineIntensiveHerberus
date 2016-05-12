using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OpenDoor : MonoBehaviour 
{
    int playerID;
	GameObject mainDoor;
	bool canTriggerCoroutine;



	void Start()
	{
        playerID = GetComponent<Movement>().playerID;
        canTriggerCoroutine = true;
        mainDoor = GameObject.Find("Main_Door");
	}



    void OnTriggerStay(Collider other)
    {
        // Normal Doors
        if (other.GetComponent<Collider>().gameObject.tag == "LeverDoor")
        {
            if (XInput.instance.getButton(playerID, 'A') == XInputDotNetPure.ButtonState.Pressed)
			//if (Input.GetKey(KeyCode.Space))
			{				
                if (canTriggerCoroutine == true)
                {
                    Lever _Lever = other.GetComponent<Lever>();

                    if (_Lever.coroutineIsRunning == false)
                    {
						//StartCoroutine(FeedbackTimer());
                        _Lever.isIncreasing = true;
                        _Lever.StartCoroutine(other.GetComponent<Lever>().DoorState());
                        canTriggerCoroutine = false;
                    }
                }
            }

            else
            {
                if (canTriggerCoroutine == false)
                {
                    ResetVariables(other);
                }
            }
        }
            // Main door
            if (other.GetComponent<Collider>().gameObject.tag == "LeverMainDoor")
            {
                if (XInput.instance.getButton(playerID, 'A') == XInputDotNetPure.ButtonState.Pressed || Input.GetKey(KeyCode.Space))
                {
                    MainDoorTrigger _RefToTrigger = other.GetComponent<MainDoorTrigger>();

                    if (_RefToTrigger.isActivated == false)
                    {
                        _RefToTrigger.isActivated = true;
                        mainDoor.GetComponent<MainDoor>().CheckDoorStatus();
                    }
                }
            }
        }
       


	void OnTriggerExit (Collider other)
	{
		ResetVariables(other);
	}



	void ResetVariables(Collider lever)
	{
		// Lever
		if (lever.GetComponent<Lever>())
		{
			lever.GetComponent<Lever>().isIncreasing = false;
		}

		// Player
		canTriggerCoroutine = true;
	}
}