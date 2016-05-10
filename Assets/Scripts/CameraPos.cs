using UnityEngine;
using System.Collections;

public class CameraPos : MonoBehaviour {
    Transform target;
    [Header("Position")]
    public float xOffSet;
    public float yOffSet;
    public float zOffSet;

    [Header("Rotation")]
    [Range(-1, 1)]
    public float xRotation;
    [Range(-1, 1)]
    public float yRotation;
    [Range(-1, 1)]
    public float zRotation;
    [Range(-1, 1)]
    public float wQuaternion;

    void Start () {
        target = GameObject.Find("Players").transform;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = target.position;
        transform.position = new Vector3(pos.x+ xOffSet, pos.y+ yOffSet, pos.z+ zOffSet);
        transform.rotation = new Quaternion(xRotation, yRotation, zRotation, wQuaternion);
	}
}
