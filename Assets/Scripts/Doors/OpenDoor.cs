using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour 
{
	//public GameObject mainDoor;
	//MainDoor refToMainDoorScript;
	bool canTriggerCoroutine;

	void Start()
	{
		canTriggerCoroutine = true;
		//refToMainDoorScript = mainDoor.GetComponent<MainDoor>();
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