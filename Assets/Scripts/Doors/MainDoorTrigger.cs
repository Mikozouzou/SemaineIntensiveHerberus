using UnityEngine;
using System.Collections;

public class MainDoorTrigger : MonoBehaviour 
{
	//[HideInInspector]
	public bool isActivated;

	void Start()
	{
		isActivated = false;
	}
}