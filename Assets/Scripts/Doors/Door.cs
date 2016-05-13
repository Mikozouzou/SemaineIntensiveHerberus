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

		if (isOpened == true)
		{
			animator.speed = 100;
			animator.SetTrigger("OpenTheDoor");

			StartCoroutine(SetUpDoor());
		}
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
		


	IEnumerator SetUpDoor()
	{
		yield return new WaitForSeconds(0.1f);
		animator.speed = 1;
	}
}