using UnityEngine;
using System.Collections;

public class MainDoor : MonoBehaviour 
{
	public GameObject[] triggers;
	[HideInInspector]
	public int DoorCount;

	void Start()
	{
		DoorCount = 0;
	}

	public void CheckDoorStatus()
	{
        print("1");
        DoorCount++;
		if (DoorCount >= triggers.Length)
		{

			Door _MainDoorOpening = GetComponent<Door>();
			_MainDoorOpening.isOpened = true;
			_MainDoorOpening.ChangePosition();

			this.enabled = false;
		}
	}
}