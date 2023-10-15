using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class flickerLight : MonoBehaviour {

    public AudioClip lightSound;
    public AudioSource audioSource;

    public GameObject[] lights;

    public GameObject cube;
    public Material onMaterial;
    public Material offMaterial;

    public bool isOn;

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

            if (isOn == true)
            {
                LighOff();
            }
            else
            {
                LighOn();
            }
		}
	}

    public void LighOn()
    {
        foreach (GameObject light in lights)
        {
            {
                
                Renderer renderer = cube.GetComponent<Renderer>();
                Material materials = renderer.material;
                Light[] lightCompoment = light.GetComponentsInChildren<Light>();
                foreach (Light lichter in lightCompoment)
                {
                    cube.GetComponent<MeshRenderer>().material = onMaterial;
                    audioSource.clip = lightSound;
                    audioSource.Play();
                    lichter.enabled = true;
                }
                isOn = true;
            }
        }
    }
    public void LighOff()
    {
        foreach (GameObject light in lights)
        {
            {
                Renderer renderer = cube.GetComponent<Renderer>();
                Material materials = renderer.material;
                Light[] lightCompoment = light.GetComponentsInChildren<Light>();

                foreach (Light lichter in lightCompoment)
                {
                    cube.GetComponent<MeshRenderer>().material = offMaterial;
                    lichter.enabled = false;
                    audioSource.clip = lightSound;
                    audioSource.Stop();
                }
                isOn = false;
            }
        }
    }
}
