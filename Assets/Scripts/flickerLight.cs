using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flickerLight : MonoBehaviour {

    public Light theLight;
    public Light theLight2;
    public GameObject lightObject;

	[SerializeField]
	float minTimeBeforeLightFlickers;
	[SerializeField]
	float maxTimeBeforeLightFlicker;

	void Start ()
	{
		StartCoroutine("MakeLightFlicker");
	}

    IEnumerator MakeLightFlicker()
	{
		while (true)
		{
			yield return new WaitForSeconds(Random.Range(minTimeBeforeLightFlickers, maxTimeBeforeLightFlicker));
            theLight.enabled = !theLight.enabled;
            lightObject.SetActive(theLight.enabled);

			if (theLight2 != null ) {
                theLight2.enabled = !theLight2.enabled;
                lightObject.SetActive(theLight2.enabled);
            }
        }
	} 
}
