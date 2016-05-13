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

			// Désolé pour cette coroutine.
			StartCoroutine(SetUpDoor());
		}
	}

    public void closeDoor()
    {
        if (isOpened)
            animator.SetTrigger("CloseTheDoor");
        isOpened = false;
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



	// Cette couroutine a été créée par un professionel. Ne faites pas ça chez vous.
	IEnumerator SetUpDoor()
	{
		yield return new WaitForSeconds(0.1f);
		animator.speed = 1;
	}
}