using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class StalkSound : MonoBehaviour
{
    private AudioSource audioSource;

   void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }
     void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            audioSource.Play();
        }
        
    }
}