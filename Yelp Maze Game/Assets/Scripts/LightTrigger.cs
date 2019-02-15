using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class LightTrigger : MonoBehaviour
{
  
    AudioSource audioSource;
    public Light lightToSwitch = null;
    private float fadeStart = 0.5f;
    private float fadeEnd = 5f;
    private float fadeTime = 2;
    private float t = 0;
    
    
    private void Start()

    {
        lightToSwitch.intensity = 0;
        audioSource = GetComponent<AudioSource>();
    }
    

    public void OnTriggerEnter(Collider other) 
    {
        IntensityChange();

        if (other.gameObject.CompareTag("Player"))        
            {
                audioSource.Play();
            }
    }


    public void IntensityChange()
    {
        while (t < fadeTime)
        {
            t += Time.deltaTime;

            lightToSwitch.intensity = Mathf.Lerp(fadeStart, fadeEnd, t * fadeTime);
        }
    }
}
