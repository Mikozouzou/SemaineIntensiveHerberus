using UnityEngine;
using System.Collections;

public class Slowzone : MonoBehaviour 
{
	[Range(1, 99)]
	public float slowAmount;
	float slowAmountPercentage;
	float originalSpeed;

	void Start()
	{
		slowAmountPercentage = 1 - (slowAmount * 0.01f);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<Collider>().gameObject.tag == "Player")
		{
			Movement _Movement = other.GetComponentInParent<Movement>();
			print("Move: " + _Movement);
			originalSpeed = _Movement.speed;
			_Movement.speed *= slowAmountPercentage;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.GetComponent<Collider>().gameObject.tag == "Player")
		{
			Movement _Movement = other.GetComponentInParent<Movement>();
			_Movement.speed = originalSpeed;
		}
	}
}