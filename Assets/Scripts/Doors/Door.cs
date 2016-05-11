using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour 
{
	[HideInInspector]
	public Vector3 closedPosition;
	[HideInInspector]
	public Vector3 openedPosition;
	public bool isOpened;
    Animator animator;

	void Start () 
	{
        animator = GetComponentInChildren<Animator>();
		//ChangePosition();
	}

	public void ChangePosition()
	{
		if (isOpened == true)
		{
            animator.SetTrigger("OpenTheDoor");
		}

		else
		{
            animator.SetTrigger("CloseTheDoor");
        }
	}
}