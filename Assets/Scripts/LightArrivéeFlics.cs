using UnityEngine;
using System.Collections;

public class LightArrivéeFlics : MonoBehaviour
{
    Light datLight;

	void Start ()
    {
        datLight = this.GetComponent<Light>();
        StartCoroutine(Clignotement());
	}

    IEnumerator Clignotement ()
    {
        while(this != null)
        {
            //Debug.Log("lol");
            datLight.color = Color.red;
            yield return new WaitForSeconds(0.5f);
            datLight.color = Color.blue;
            yield return new WaitForSeconds(0.5f);
            //Debug.Log("lol2");
        }
        yield return null;
    }
}
