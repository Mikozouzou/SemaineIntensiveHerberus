using UnityEngine;
using System.Collections;

public class OpenMainDoor : MonoBehaviour 
{
	public GameObject refMainDoor;
	MainDoor refToMainDoorScript;

	void Start ()
	{
		refToMainDoorScript = refMainDoor.GetComponent<MainDoor>();
	}


	void OnTriggerStay(Collider other)
	{
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
}
