using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour 
{
	[HideInInspector]
	public Vector3 closedPosition;
	[HideInInspector]
	public Vector3 openedPosition;
	[HideInInspector]
	public bool isOpened;

	void Start () 
	{
		closedPosition = transform.position;
		openedPosition = transform.position + new Vector3(0, 50, 0);

		ChangePosition();
	}

	public void ChangePosition()
	{
		if (isOpened == true)
		{
			transform.position = openedPosition;
		}

		else
		{
			transform.position = closedPosition;
		}
	}
}