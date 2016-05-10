using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour 
{
	public GameObject mainDoor;
	MainDoor refToMainDoorScript;
	bool canTriggerCoroutine;

	void Start()
	{
		canTriggerCoroutine = true;
		refToMainDoorScript = mainDoor.GetComponent<MainDoor>();
	}

	void OnTriggerStay (Collider other)
	{
		// Normal Doors
		if (other.GetComponent<Collider>().gameObject.tag == "LeverDoor")
		{
			if (Input.GetKey(KeyCode.Space))
			{
				if (canTriggerCoroutine == true)
				{
					other.GetComponent<Lever>().isIncreasing = true;
					other.GetComponent<Lever>().StartCoroutine(other.GetComponent<Lever>().DoorState());
					canTriggerCoroutine = false;
				}
			}
				
			else
			{
				ResetVariables(other);
			}
		}

		// Main doors
		if (other.GetComponent<Collider>().gameObject.tag == "LeverMainDoor")
		{
			if (Input.GetKey(KeyCode.Space))
			{
				MainDoorTrigger _MainTrigger = other.GetComponent<MainDoorTrigger>();

				if (_MainTrigger.isActivated == false)
				{
					_MainTrigger.isActivated = true;
					refToMainDoorScript.DoorCount++;
					refToMainDoorScript.CheckDoorStatus();
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