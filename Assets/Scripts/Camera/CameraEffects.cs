using UnityEngine;
using System.Collections;

public class CameraEffects : MonoBehaviour
{
    public static CameraEffects instance;
    Camera cam;
    Transform camTransf;
    public float power;

	void Awake ()
    {
	    if (instance == null)
        {
            instance = this;
        }
	}

    void Start()
    {
        cam = this.GetComponent<Camera>();
        camTransf = cam.transform;
    }
	
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(Screenshake());
    }

	IEnumerator Screenshake ()
    {
        camTransf.position += Vector3.left * power;
        camTransf.position += Vector3.forward * power;
        yield return new WaitForSeconds(0.02f);
        camTransf.position -= Vector3.left * power*2;
        camTransf.position -= Vector3.forward * power*2;
        yield return new WaitForSeconds(0.02f);
        camTransf.position += Vector3.left * power;
        camTransf.position += Vector3.forward * power;
        yield return new WaitForSeconds(0.02f);
        camTransf.position += Vector3.left * power * 2;
        yield return new WaitForSeconds(0.02f);
        camTransf.position -= Vector3.left * power * 2;
    }
}
