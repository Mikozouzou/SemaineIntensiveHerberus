using UnityEngine;
using System.Collections;

public class Lever : MonoBehaviour 
{
	public GameObject doorReference;
	public float openingTimer;
	bool canIncreaseTimer;
	public bool isIncreasing;
	public bool isOpened;

	Vector3 closedPosition;
	Vector3 openedPosition;

	void Start()
	{
		// Set the positions of the doors
		closedPosition = doorReference.transform.position;
		openedPosition = doorReference.transform.position + new Vector3(0, 50, 0);
	}

	void OnTriggerEnter (Collider other)
	{
		
		if (other.GetComponent<Collider>().gameObject.tag == "Player")
		{
			canIncreaseTimer = true;
		}
	}

	void OnTriggerExit ()
	{
		canIncreaseTimer = false;
	}

	public IEnumerator DoorState()
	{
		int _timer = 0;
		int _timerMax = 10; // Just made so that we have a timer

		while (_timer < _timerMax)
		{
			yield return new WaitForSeconds(openingTimer / _timerMax);
			_timer++;

			if (isIncreasing == false)
			{
				yield break;
			}
		}

		if (_timer >= _timerMax)
		{
			if (isIncreasing == true) // if increasing is still true, then, we open/close the door
			{
				if (isOpened == true)
				{
					ChangeDoorState(true);
					//yield break;
				}

				else
				{
					ChangeDoorState(false);
					//yield break;
				}
			}

			else 
			{
				yield break;
			}
		}
	}

	// If open --> close	;	If close --> open
	void ChangeDoorState(bool newState)
	{
		isOpened = newState;

		if (isOpened == true)
		{
			doorReference.transform.position = closedPosition;
			isOpened = false;
		}

		else
		{
			doorReference.transform.position = openedPosition;
			isOpened = true;
		}
	}
}