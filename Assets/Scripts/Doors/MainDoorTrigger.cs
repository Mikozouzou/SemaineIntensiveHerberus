using UnityEngine;
using System.Collections;

public class MainDoorTrigger : MonoBehaviour 
{
	//[HideInInspector]
	public bool isActivated;
    public Light[] lights;
    float intensity;
	void Start()
	{
        lights = GetComponentsInChildren<Light>();
        intensity = lights[0].intensity;
        foreach (Light light in lights)
        {
            light.intensity = 0;
        }
        isActivated = false;
	}

    void OnTriggerEnter(Collider col)
    {
        if (!isActivated)
        {
            foreach (Light light in lights)
            {
                light.intensity = intensity;
            }
        }
    }
}