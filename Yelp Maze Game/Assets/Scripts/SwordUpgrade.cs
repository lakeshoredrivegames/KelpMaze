using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class SwordUpgrade : MonoBehaviour
{
    public AudioClip newSword;
    AudioSource audioSource;
    
    private float counter = 0;
    private void Start()

    {
        audioSource = GetComponent<AudioSource>();
    }
    

    public void OnTriggerEnter(Collider other) 
    {

        if (other.gameObject.CompareTag("Player") && (counter < 1))        
            {
                audioSource.PlayOneShot(newSword,0.9f);
                counter++;
            }
    }
}