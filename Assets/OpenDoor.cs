using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour 
{
	public bool canTriggerCoroutine;

	void Start()
	{
		canTriggerCoroutine = true;
	}

	void OnTriggerStay (Collider other)
	{
		if (other.GetComponent<Collider>().gameObject.tag == "Levier")
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