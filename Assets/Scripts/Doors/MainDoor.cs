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
        //lights = GetComponentsInChildren<Light>();
        //foreach (Light light in lights)
        //{
        //    light.intensity = 0;

        //}
	}

	public void CheckDoorStatus()
	{
        //enableLight();
        DoorCount++;
		if (DoorCount >= triggers.Length)
		{

			Door _MainDoorOpening = GetComponent<Door>();
			_MainDoorOpening.isOpened = true;
			_MainDoorOpening.ChangePosition();

			this.enabled = false;
		}
	}

    //void enableLight()
    //{
    //    lights[countLight].intensity = lightIntensity;
    //    countLight++;
    //    lights[countLight].intensity = lightIntensity;
    //    countLight++;
    //}
}