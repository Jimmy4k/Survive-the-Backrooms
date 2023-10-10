using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flickerLight : MonoBehaviour {

	public Light theLight;
	//public GameObject lightObject;

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
			//lightObject.SetActive(theLight.enabled);
		}
	} 
}
