using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Credits : MonoBehaviour
{
	
	void Update ()
    {
	    if (XInput.instance.getButton(1,'B') == XInputDotNetPure.ButtonState.Pressed || XInput.instance.getButton(1, 'A') == XInputDotNetPure.ButtonState.Pressed)
        {
            SceneManager.LoadScene(0);
        }
	}
}
