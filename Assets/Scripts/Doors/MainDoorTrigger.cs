using UnityEngine;
using System.Collections;

public class MainDoorTrigger : MonoBehaviour 
{
	//[HideInInspector]
	public bool isActivated;
    public Light[] lights;
    float intensity;

	Renderer rend;
	float basicEmissive;
	float currentEmissive;
	float maxEmissive;
	public Color activatedColor;
	public float emissiveVariation;
	public float glowSpeed;

	void Start()
	{
		isActivated = false;
		rend = transform.parent.GetChild(0).transform.GetChild(0).GetComponent<Renderer>();
        lights = GetComponentsInChildren<Light>();
        intensity = lights[0].intensity;
        foreach (Light light in lights)
        {
            light.intensity = 0;
        }
        basicEmissive = rend.material.GetFloat("_EmissiveValue");
		maxEmissive = basicEmissive + emissiveVariation;
        currentEmissive = basicEmissive;
             
		StartCoroutine(Glow());
	}



	public void ChangeState()
	{
		rend.material.SetColor("_CurrentState", activatedColor);
	}



	IEnumerator Glow()
	{
        
		while (this.gameObject.activeInHierarchy)
		{
       
            if (rend.material.GetFloat("_EmissiveValue") < maxEmissive)
			{
				while (rend.material.GetFloat("_EmissiveValue") < maxEmissive) 
				{
                 
                    currentEmissive += glowSpeed;
					rend.material.SetFloat("_EmissiveValue", currentEmissive);
					yield return new WaitForEndOfFrame();
				}
			}

			if (rend.material.GetFloat("_EmissiveValue") > basicEmissive)
			{
				while (rend.material.GetFloat("_EmissiveValue") > basicEmissive) 
				{
					currentEmissive -= glowSpeed;
					rend.material.SetFloat("_EmissiveValue", currentEmissive);
					yield return new WaitForEndOfFrame();
				}
			}
		}
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