using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightOnOff : MonoBehaviour
{
    public AudioClip lightOnSound;
    public AudioClip lightOffSound;
    public AudioSource audioSource;

    public GameObject[] lights;

    public Material onMaterial;
    public Material offMaterial;

    public bool isOn; 
    

    private bool enterTrigger;

    private void Update()
    {
        if (isOn == true)
        {
            LighOff();
        }
        else
        {
            LighOn();
        }
    }

    public void LighOn()
    {
        foreach (GameObject light in lights)
        {
            {
                MeshRenderer[] meshRenderer = light.GetComponentsInChildren<MeshRenderer>();
                Light[] lightCompoment = light.GetComponentsInChildren<Light>();

                foreach (MeshRenderer renderer in meshRenderer)
                {
                    renderer.material = onMaterial;
                }
                foreach (Light lichter in lightCompoment)
                {
                    audioSource.clip = lightOffSound;
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
                MeshRenderer[] meshRenderer = light.GetComponentsInChildren<MeshRenderer>();
                Light[] lightCompoment = light.GetComponentsInChildren<Light>();

                foreach (MeshRenderer renderer in meshRenderer)
                {
                    renderer.material = offMaterial;
                }
                foreach (Light lichter in lightCompoment)
                {
                    lichter.enabled = false;
                    audioSource.clip = lightOffSound;
                    audioSource.Play();
                }
                isOn = false;
            }
        } 
    }
}
