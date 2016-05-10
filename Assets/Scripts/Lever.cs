using UnityEngine;
using System.Collections;

public class Lever : MonoBehaviour 
{
	public GameObject[] doorReference;
	public float openingTimer;
	[HideInInspector]
	public bool isIncreasing;
	bool isOpened;

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
			if (isIncreasing == true) // If still true, we change all doors' state
			{
				for (int i = 0 ; i < doorReference.Length ; i++)
				{
					Door _door = doorReference[i].GetComponent<Door>();

					if (_door.isOpened == false)
					{
						_door.isOpened = true;
					}

					else 
					{
						_door.isOpened = false;
					}

					_door.ChangePosition();
				}
			}
		}
	}

	// If open --> close	;	If close --> open
	void ChangeDoorState(bool newState)
	{
		isOpened = newState;

		if (isOpened == true)
		{
			for (int i = 0 ; i < doorReference.Length ; i++)
			{
				doorReference[i].transform.position = doorReference[i].GetComponent<Door>().closedPosition;
				isOpened = false;
			}
		}

		else
		{
			for (int i = 0 ; i < doorReference.Length ; i++)
			{
				doorReference[i].transform.position = doorReference[i].GetComponent<Door>().openedPosition;
				isOpened = true;
			}
		}
	}
}