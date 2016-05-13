using UnityEngine;
using System.Collections;

public class CameraScrolling : MonoBehaviour {
    public static CameraScrolling instance;
    public float[] positionXList;
    int indexPos = 0;
    float currentPos;
	// Use this for initialization
	void Start () {
        instance = this;
        currentPos = transform.position.x;
    }
	
	// Update is called once per frame
	void Update () {
            transform.position = Vector3.Lerp(transform.position, new Vector3(currentPos, transform.position.y,transform.position.z),  0.05f);
        if (Input.GetKeyDown(KeyCode.W))
        {
            moveNextRoom();
        }
	}

    public void moveNextRoom()
    {
        if (positionXList.Length > indexPos)
        {
            currentPos = positionXList[indexPos];
            indexPos++;
        }
        
    }
}
