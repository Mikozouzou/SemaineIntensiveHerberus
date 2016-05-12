using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Lever : MonoBehaviour 
{
	public GameObject[] doorReference;
	public float openingTimer;
	[HideInInspector]
	public bool isIncreasing;
	[HideInInspector]
	public bool coroutineIsRunning;
	public Image imageFeedback;
	bool isOpened;

    void Start()
    {
        imageFeedback = transform.parent.FindChild("Canvas").FindChild("Lever_Door_Loading").GetComponent<Image>();
    }

	public IEnumerator DoorState()
	{
		if (coroutineIsRunning == false)
		{
			coroutineIsRunning = true;
		}

		else 
		{
			coroutineIsRunning = false;
			yield break;
		}

		int _timer = 0;
		float _timerMax = 90; // Just made so that we have a "timer". Also used as the number of parts to fill in the gap of the image.
		float _interval = openingTimer / _timerMax;

		while (_timer < _timerMax)
		{
			if (isIncreasing)
			{
				_timer++;
				imageFeedback.fillAmount += _interval;

				if (_timer >= _timerMax)
				{
					break;	
				}

				yield return new WaitForSeconds(_interval);
			}

			else 
			{
				imageFeedback.fillAmount = 0;
				break;
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

			imageFeedback.fillAmount = 0; // reset image
		}

		coroutineIsRunning = false;
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