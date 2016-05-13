using UnityEngine;
using System.Collections;

public class Gyrophgare : MonoBehaviour
{
    public int speed;
    public bool invertedRotation;
    int direction = 1;

    void Start()
    {
        if (invertedRotation)
            direction = -1;
    }

	void Update ()
    {
        transform.Rotate(Vector3.up * Time.deltaTime *(speed* direction));
    }
}
