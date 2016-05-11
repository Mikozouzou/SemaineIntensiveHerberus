using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour 
{
    int playerID;
	public GameObject mainDoor;
	//MainDoor refToMainDoorScript;
	bool canTriggerCoroutine;

	void Start()
	{
        playerID = GetComponent<Movement>().playerID;
        canTriggerCoroutine = true;
		//refToMainDoorScript = mainDoor.GetComponent<MainDoor>();
	}

    void OnTriggerStay(Collider other)
    {
        // Normal Doors
        if (other.GetComponent<Collider>().gameObject.tag == "LeverDoor")
        {
            if (XInput.instance.getButton(playerID, 'A') == XInputDotNetPure.ButtonState.Pressed)
            {
                if (canTriggerCoroutine == true)
                {
                    Lever _Lever = other.GetComponent<Lever>();

                    if (_Lever.coroutineIsRunning == false)
                    {
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
                if (XInput.instance.getButton(playerID, 'A') == XInputDotNetPure.ButtonState.Pressed)
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