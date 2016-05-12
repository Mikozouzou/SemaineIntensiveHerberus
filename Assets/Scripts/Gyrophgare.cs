using UnityEngine;
using System.Collections;

public class Gyrophgare : MonoBehaviour
{
    public int speed;
	void Update ()
    {
        transform.Rotate(Vector3.up * Time.deltaTime *speed);
    }
}
