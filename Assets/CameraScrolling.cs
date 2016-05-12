using UnityEngine;
using System.Collections;

public class CameraScrolling : MonoBehaviour {
    public static CameraScrolling instance;
    public Vector3[] positionList;
    int indexPos = 0;
    Vector3 currentPos;
	// Use this for initialization
	void Start () {
        instance = this;
        currentPos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
            transform.position = Vector3.Lerp(transform.position, currentPos, 0.05f);
        if (Input.GetKeyDown(KeyCode.W))
        {
            moveNextRoom();
        }
	}

    public void moveNextRoom()
    {
        if (positionList.Length > indexPos)
        {
            currentPos = positionList[indexPos];
            indexPos++;
        }
        
    }
}
